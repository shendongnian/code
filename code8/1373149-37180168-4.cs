    public static class Algorithms
    {
    	public static IEnumerable<string> GetCombinations(this string input, Dictionary<char, string[]> replacements)
    	{
    		var map = new string[input.Length][];
    		for (int i = 0; i < map.Length; i++)
    		{
    			var c = input[i];
    			string[] r;
    			map[i] = replacements.TryGetValue(c, out r)
    				&& (r = r.Where(s => !string.IsNullOrEmpty(s)).ToArray()).Length > 0 ?
    				r : new string[] { c.ToString() };
    		}
    		int maxLength = map.Sum(output => output.Max(s => s.Length));
    		var buffer = new char[maxLength];
    		int length = 0;
    		var indices = new int[input.Length];
    		for (int pos = 0, index = 0; ;)
    		{
    			for (; pos < input.Length; pos++, index = 0)
    			{
    				indices[pos] = index;
    				foreach (var c in map[pos][index])
    					buffer[length++] = c;
    			}
    			yield return new string(buffer, 0, length);
    			do
    			{
    				if (pos == 0) yield break;
    				index = indices[--pos];
    				length -= map[pos][index].Length;
    			}
    			while (++index >= map[pos].Length);
    		}
    	}
    }
