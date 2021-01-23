    public string ReplaceXMLEncodedCharacters(string input)
	{
		const string pattern = @"&#(x?)([A-Fa-f0-9]+);";
		MatchCollection matches = Regex.Matches(input, pattern);
        int offset = 0;
		foreach (Match match in matches)
		{
			int charCode = 0;
			if (string.IsNullOrEmpty(match.Groups[1].Value))
				charCode = int.Parse(match.Groups[2].Value);
			else
				charCode = int.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.HexNumber);
			char character = (char)charCode;
			input = input.Remove(match.Index - offset, match.Length).Insert(match.Index - offset, character.ToString());
            offset += match.Length - 1;
		}
		return input;
	}
