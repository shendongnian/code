	public static int GetMatchCount(string searchFor, string searchIn)
	{
		if (string.IsNullOrEmpty(searchFor) || string.IsNullOrEmpty(searchIn))
			return 0;
		var patternBuilder = new StringBuilder();
		foreach (var searchChar in searchFor)
			patternBuilder.Append(Regex.Escape(searchChar.ToString())).Append(".*?");
		patternBuilder.Length -= 3;
		patternBuilder.Append("(?C1)");
		var pattern = new PcreRegex(patternBuilder.ToString());
		var count = 0;
		pattern.Match(searchIn, callout =>
		{
			++count;
			return PcreCalloutResult.Fail;
		});
		return count;
	}
	
