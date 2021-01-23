    using System.Collections.Generic;
    using System.Linq;
    using System;
    
    public class Junk
    {
    	public static void Main()
    	{
    		var list1 = new List<int>(){1, 2, 3};
    		var list2 = new List<int>() { 2, 3, 4 };
    		
    		var union = list1.Union(list2);
    		var intersection = list1.Intersect(list2);
    
    		foreach (var i in union.Except(intersection))
    		{
    			Console.WriteLine(i); //prints 1 and 4
    		}
    	}
    }
