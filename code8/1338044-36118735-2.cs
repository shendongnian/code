	public static void PrintMatches(string searchFor, string searchIn)
	{
		if (string.IsNullOrEmpty(searchFor) || string.IsNullOrEmpty(searchIn))
			return;
		var patternBuilder = new StringBuilder();
		foreach (var searchChar in searchFor)
			patternBuilder.Append("(").Append(Regex.Escape(searchChar.ToString())).Append(").*?");
		patternBuilder.Length -= 3;
		patternBuilder.Append("(?C1)");
		var pattern = new PcreRegex(patternBuilder.ToString());
		var outputBuilder = new StringBuilder();
		Console.WriteLine(searchIn);
		pattern.Match(searchIn, callout =>
		{
			outputBuilder.Clear();
			outputBuilder.Append(' ', searchIn.Length);
			foreach (var group in callout.Match.Groups.Skip(1))
				outputBuilder[group.Index] = '^';
			Console.WriteLine(outputBuilder);
			return PcreCalloutResult.Fail;
		});
	}
	
