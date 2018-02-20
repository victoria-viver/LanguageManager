using System;
using System.Text.RegularExpressions;
using UnityEngine;

public static class LanguageManager 
{
    #region Constants
	private const string HEBREW_PATTERN = @"[\p{IsHebrew}]";
	private const string ENGLISH_PATTERN_PARTS = @"[a-zA-Z][a-zA-Z\s-]*[a-zA-Z]";
	#endregion


	#region Private Fields
    #endregion


	#region Public Fields
    #endregion


	#region Prefabs
	#endregion

	#region Private Methods
	private static bool isHebrew (string text)
	{
		return Regex.IsMatch (text, HEBREW_PATTERN);
	}

	private static bool hasEnglishParts (string text)
	{
		Debug.Log(Regex.IsMatch (text, ENGLISH_PATTERN_PARTS));
		return Regex.IsMatch (text, ENGLISH_PATTERN_PARTS);
	}

	private static string Reverse (string text)
	{
		char [] inputCharArray = text.ToCharArray ();
		Array.Reverse(inputCharArray);
		return new string (inputCharArray);
	}

	private static string ReverseEnglishParts (string text)
	{
		MatchCollection matches = new Regex (ENGLISH_PATTERN_PARTS).Matches(text);

		for (int i = 0; i < matches.Count; i++)
		{
			text = text.Replace (matches[i].Groups[0].Value, Reverse(matches[i].Groups[0].Value));
		}

		return text;
	}
    #endregion
	

	#region Public Methods
	public static string GetText (string text)
    {
        if (isHebrew(text))
		{
			Debug.Log("before reverse: " + text);
			text = Reverse(text);
			Debug.Log("after reverse: " + text);
		
			if (hasEnglishParts(text))
            	text = ReverseEnglishParts(text);
			Debug.Log("after reverse english: " + text);
		}
        return text;
    }
    #endregion
}