    public static IEnumerable<T[]> RepeatingPermutations<T>(this T[] set, int N)
    {
    	var result = new T[N];
    	var indices = new int[N];
    	for (int pos = 0, index = 0; ;)
    	{
    		for (; pos < N; pos++, index = 0)
    		{
    			indices[pos] = index;
    			result[pos] = set[index];
    		}
    		yield return result;
    		do
    		{
    			if (pos == 0) yield break;
    			index = indices[--pos] + 1;
    		}
    		while (index >= set.Length);
    	}
    }
