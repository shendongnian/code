    public static class Algorithms
    {
    	private static readonly char[] alpha = Enumerable.Range('a', 'z' - 'a' + 1).Select(c => (char)c).ToArray();
    
    	public static IEnumerable<string> GenerateWords(this string pattern)
    	{
    		return pattern.GenerateWordsCore().Select(word => new string(word));
    	}
    
    	public static IEnumerable<char[]> GenerateWordsCore(this string pattern)
    	{
    		var distinctSet = pattern.Select(c => c - '0').Distinct().ToArray();
    		var indexMap = pattern.Select(c => Array.IndexOf(distinctSet, c - '0')).ToArray();
    		var result = new char[pattern.Length];
    		var indices = new int[distinctSet.Length];
    		var indexUsed = new bool[alpha.Length];
    		for (int pos = 0, index = 0; ;)
    		{
    			// Generate the next permutation
    			if (index < alpha.Length)
    			{
    				if (indexUsed[index]) { index++; continue; }
    				indices[pos] = index;
    				indexUsed[index] = true;
    				if (++pos < distinctSet.Length) { index = 0; continue; }
    				// Populate and yield the result
    				for (int i = 0; i < indexMap.Length; i++)
    					result[i] = alpha[indices[indexMap[i]]];
    				yield return result;
    			}
    			// Advance to next permutation if any
    			if (pos == 0) yield break;
    			index = indices[--pos];
    			indexUsed[index] = false;
    			index++;
    		}
    	}
    }
