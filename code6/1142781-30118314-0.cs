    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var array1 = new int[]{1,2,3,4};
    		var array2 = new int[]{353, 588, 213, 353};
    		
    		var result = array1.Zip(array2, (a1, a2)=>new {Index = a1, Value = a2})
                               .GroupBy(pair=>pair.Value).ToList();
    		
    		array2 = result.Select(gr=>gr.Key).ToArray();
    		array1 = result.Select(gr=>gr.Sum(pair=>pair.Index)).ToArray();
    		
    		Console.WriteLine(String.Join(", ", array1));		
    		Console.WriteLine(String.Join(", ", array2));
    	}
    }
