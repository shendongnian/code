    public static IEnumerable<string> GetCombinations(this string input, Dictionary<char, char> replacements)
    {
    	return input.Select(c =>
    	{
    		char r;
    		return replacements.TryGetValue(c, out r) && c != r ? new[] { c, r } : new[] { c };
    	}).ToArray().GetCombinations();
    }
