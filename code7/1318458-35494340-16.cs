    public static class Algorithms
    {
        public static IEnumerable<string> GetCombinations(this char[][] input)
        {
        	var result = new char[input.Length]; 
        	var indices = new int[input.Length];
        	for (int pos = 0, index = 0; ;)
        	{
        		for (; pos < input.Length; pos++, index = 0)
        		{
        			indices[pos] = index;
        			result[pos] = input[pos][index];
        		}
        		yield return new string(result);
        		do
        		{
        			if (pos == 0) yield break;
        			index = indices[--pos] + 1;
        		}
        		while (index >= input[pos].Length);
        	}
        }
    }
