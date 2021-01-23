    public static class Algorithms
    {
    	public static IEnumerable<int> AllSums(this int[] source)
    	{
    		var indices = new int[source.Length];
    		for (int count = 0, sum = 0, next = 0; ; next++)
    		{
    			if (next < source.Length)
    			{
    				indices[count++] = next;
    				sum += source[next];
    				yield return sum;
    			}
    			else
    			{
    				if (count == 0) break;
    				next = indices[--count];
    				sum -= source[next];
    			}
    		}
    	}
    }
