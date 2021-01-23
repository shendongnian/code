    using System;
    using System.Collections.Generic;
    
    using System.Linq;
    
    public class Program
    {
    	static List<Tuple<string, string>> myList = new List<Tuple<string, string>>()
    	{
    		Tuple.Create<string, string>("B", "A"),
    		Tuple.Create<string, string>("A", "B"), // duplicate
    		Tuple.Create<string, string>("C", "B"),
    		Tuple.Create<string, string>("C", "B"), // duplicate
    		Tuple.Create<string, string>("A", "D"),
    		Tuple.Create<string, string>("E", "F"),
    		Tuple.Create<string, string>("F", "E"), // duplicate		
    	};
    
    	public static void Main()
    	{
    
    		var result =
    			from y in 
    			    from x in myList
        			select new { Original = x, SortedPair = new[] { x.Item1, x.Item2 }.OrderBy(s => s).ToArray() }	
        			group y by new { NormalizedTuple = Tuple.Create<string,string>(y.SortedPair[0], y.SortedPair[1]) } into grp
    			select new { Pair = grp.Key.NormalizedTuple, Original = grp.First().Original };
    
    
    		foreach(var item in result)
    		{
    			Console.WriteLine("Pair: {0} {1}", item.Original.Item1, item.Original.Item2);
    		}
    	}
    }
