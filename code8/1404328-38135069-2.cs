	void Main()
	{
		String source = "aaa wwwww fgffsd ththththt sss sgsgsgsghs bfbfb hhh sdfg kkk dhdhtrherhrhrthrthrt ddfhdetehehe kkk wdwd aaa vcvc hhh zxzx sss nbnbn";
		List<String> criteria = new List<string> { "kkk", "aaa", "sss", "hhh" };	
		var result = GetAllSubstringContainingCriteria(source, criteria)
            .OrderBy(sub => sub.Length)
            .FirstOrDefault();
	}
	
	private IEnumerable<string> GetAllSubstringContainingCriteria(string source, List<string> criteria)
	{
		var allWords = source.Split(' ');
		
		for (int i = 0; i < allWords.Length; i++)
		{
			var words = allWords.Skip(i);
			if (criteria.Contains(words.ElementAt(0)))
			{
				var lastWordIndex = GetIndexOfLastWord(words, criteria);
				if (lastWordIndex >= 0)
					yield return string.Join(" ", words.Take(lastWordIndex + 1));
	        }
			else
				continue;
		}
	}
	
	private int GetIndexOfLastWord(IEnumerable<string> words, List<string> criteria)
	{
		var indexes = criteria.Select(crit => words.ToList().IndexOf(crit));
		return indexes.All(index => index >= 0) ? indexes.Max() : -1;
	}
