    public static class Algorithms
    {
    	public static IEnumerable<T[]> GetCombinations<T>(this T[] input, int N)
    	{
    		var result = new T[N];
    		var indices = new int[N];
    		for (int pos = 0, index = 0; ;)
    		{
    			for (; pos < N; pos++, index++)
    			{
    				indices[pos] = index;
    				result[pos] = input[index];
    			}
    			yield return result;
    			do
    			{
    				if (pos == 0) yield break;
    				index = indices[--pos] + 1;
    			}
    			while (index > input.Length - N + pos);
    		}
    	}
    }
