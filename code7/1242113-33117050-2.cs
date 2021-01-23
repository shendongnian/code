    using System;
    using System.Collections.Generic;
     
    public class Test
    {
    	static Random random = new Random();
     
    	public static List<int> GenerateRandom(int count)
    	{
    		// generate count random values.
    		HashSet<int> candidates = new HashSet<int>();
    		// top will overflow to Int32.MinValue at the end of the loop
    		for (Int32 top = Int32.MaxValue - count + 1; top > 0; top++)
    		{
    			// May strike a duplicate.
    			if (!candidates.Add(random.Next(top))) {
    				candidates.Add(top);
    			}
    		}
     
    		// load them in to a list.
    		List<int> result = new List<int>();
    		result.AddRange(candidates);
     
    		// shuffle the results:
    		int i = result.Count;  
            while (i > 1)
            {  
                i--;  
                int k = random.Next(i + 1);  
                int value = result[k];  
                result[k] = result[i];  
                result[i] = value;  
            }  
    		return result;
    	}
    	public static void Main()
    	{
    		List<int> vals = GenerateRandom(10);
    		Console.WriteLine("Result: " + vals.Count);
    		vals.ForEach(Console.WriteLine);
    	}
    }
