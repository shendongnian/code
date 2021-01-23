	public static string SafeReplace(this string input, string find, string replace, bool matchWholeWord)
	{
        string textToFind = matchWholeWord ? string.Format(@"(?<=^|\s){0}(?=$|\s)", Regex.Escape(find)) : Regex.Escape(find);
        return Regex.Replace(input, textToFind, replace);
	}	
