	void Main()
	{
        String source = "aaa wwwww fgffsd ththththt sss ww sgsgsgsghs bfbfb hhh sdfg kkk " +
            "dhdhtrherhrhrthrthrt ddfhdetehehe kkk wdwd aaa vcvc hhh zxzx sss ww nbnbn";
        List<String> criteria = new List<string> { "kkk", "aaa", "sss ww", "hhh" };
        var result = GetAllSubstringContainingCriteria(source, criteria)
            .OrderBy(sub => sub.Length).FirstOrDefault();
        // result is "kkk wdwd aaa vcvc hhh zxzx sss ww"
	}
	
	private IEnumerable<string> GetAllSubstringContainingCriteria(
		string source, List<string> criteria)
	{
		for (int i = 0; i < source.Length; i++)
		{
			var subString = source.Substring(i);
			if (criteria.Any(crit => subString.StartsWith(crit)))
			{
				var lastWordIndex = 
					GetLastCharacterIndexFromLastCriteriaInSubstring(subString, criteria);
				if (lastWordIndex >= 0)
					yield return string.Join(" ", subString.Substring(0, lastWordIndex));
			}
			else
				continue;
		}
	}
	
	private int GetLastCharacterIndexFromLastCriteriaInSubstring(
		string subString, List<string> criteria)
	{
		var results = criteria.Select(crit => new { 
				index = subString.IndexOf(crit),
				criteria = crit});
        return results.All(result => result.index >= 0)
            ? results.Select(result => result.index + result.criteria.Length).Max()
            : -1;
	}
