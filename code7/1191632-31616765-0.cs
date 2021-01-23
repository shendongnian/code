    public string ReplaceXMLEncodedCharacters(string input)
	{
		const string pattern = @"&#(x?)(\d+);";
		MatchCollection matches = Regex.Matches(input, pattern);
		foreach (Match match in matches)
		{
			int charCode = 0;
			if (string.IsNullOrEmpty(match.Groups[1].Value))
				charCode = int.Parse(match.Groups[2].Value);
			else
				charCode = int.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
			char character = (char)charCode;
			input = input.Remove(match.Index, match.Length).Insert(match.Index, character.ToString());
		}
		return input;
	}
