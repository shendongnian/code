    using System;
    using System.Collections.Generic;
    
    using System.Linq;
    					
    public class Program
    {
    	static List<Tuple<string, string>> myList = new List<Tuple<string, string>>()
    	{
    		Tuple.Create<string, string>("A", "B"),
    		Tuple.Create<string, string>("B", "A"), // duplicate
    		Tuple.Create<string, string>("C", "B"),
    		Tuple.Create<string, string>("C", "B"), // duplicate
    		Tuple.Create<string, string>("A", "D")				
    	};
    	
    	public static void Main()
    	{
    		myList
    			.Select(x => new[] { x.Item1, x.Item2 }.AsEnumerable().OrderBy(s => s).ToArray())
    			.Select(x => Tuple.Create<string,string>(x[0], x[1]))
    			.Distinct()
    			.Dump();
    	}
    }
