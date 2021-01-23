    public static class Algorithms
    {
    	public static IEnumerable<T[]> GenerateCombinations<T>(this IReadOnlyList<IReadOnlyList<T>> input)
    	{
    		var result = new T[input.Count];
    		var indices = new int[input.Count];
    		for (int pos = 0, index = 0; ;)
    		{
    			for (; pos < result.Length; pos++, index = 0)
    			{
    				indices[pos] = index;
    				result[pos] = input[pos][index];
    			}
    			yield return result;
    			do
    			{
    				if (pos == 0) yield break;
    				index = indices[--pos] + 1;
    			}
    			while (index >= input[pos].Count);
    		}
    	}
    }
