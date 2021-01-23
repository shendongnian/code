    public static class Algorithms
    {
    	private static readonly char[] alpha = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();
    
    	public static IEnumerable<string> GenerateWords(this string pattern)
    	{
    		var distinctSet = pattern.Select(c => c - '0').Distinct().ToArray();
    		var indexMap = pattern.Select(c => Array.IndexOf(distinctSet, c - '0')).ToArray();
    		var result = new char[pattern.Length];
    		var indices = new int[distinctSet.Length];
    		for (int pos = 0, index = 0; ;)
    		{
    			// Generate the next combination
    			for (; pos < distinctSet.Length; pos++, index++)
    				indices[pos] = index;
    			// Populate and yield the result
    			for (int i = 0; i < indexMap.Length; i++)
    				result[i] = alpha[indices[indexMap[i]]];
    			yield return new string(result);
    			// Advance to next combination if any
    			do
    			{
    				if (pos == 0) yield break;
    				index = indices[--pos] + 1;
    			}
    			while (index >= alpha.Length - (distinctSet.Length - 1 - pos));
    		}
    	}
    }
