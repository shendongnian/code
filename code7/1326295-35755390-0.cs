	public static IEnumerable<int> GetStringIndices(IEnumerable<string> substringlist, string data)
	{
		var lstIndices = new List<int>();
		foreach (var searchString in substringlist)
		{
			var regexObj = new Regex($@"(\s|^){searchString}\b", RegexOptions.IgnoreCase | RegexOptions.Multiline);
			var matchResults = regexObj.Match(data);
			if (!matchResults.Success)
			{
				lstIndices.Add(-1);
				continue;
			}
			while (matchResults.Success)
			{
				var idx = matchResults.Index;
				lstIndices.Add(idx);
				matchResults = matchResults.NextMatch();
			}
		}
		return lstIndices;
	}
