    static void PrintCombinations(int[] input, int k)
    {
    	var indices = new int[k];
    	for (int pos = 0, index = 0; ; index++)
    	{
    		if (index < input.Length - k + pos)
    		{
    			indices[pos++] = index;
    			if (pos < k) continue;
    			// Consume the combination
    			for (int i = 0; i < k; i++)
    			{
    				if (i > 0) Console.Write(",");
    				Console.Write(input[indices[i]]);
    			}
    			Console.WriteLine();
    			pos--;
    		}
    		else
    		{
    			if (pos == 0) break;
    			index = indices[--pos];
    		}
    	}
    }
