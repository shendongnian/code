    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		foreach(var part in getParts("Category A|Category A > Sub Category 1|Category B|Category C|Category C > Sub Category 2"))
    			Console.WriteLine(part);
    		Console.WriteLine();
    
    		Console.WriteLine("TEST 2");
    		foreach(var part in getParts("Category A > THIS IS DATA IS REDUNDANT|Category A > Sub Category 1 > THIS IS DATA IS REDUNDANT|Category A > Sub Category 1 > Sub Sub Category 1|Category A > Sub Category 1 > Sub Sub Category 2"))
    			Console.WriteLine(part);
    	}
    	
    	public static List<string> getParts(string stringToParse){
    		var parts = stringToParse.Split('|').Select(part => part.Trim());
    		return parts.Where(part => !parts.Any(comparePart => part != comparePart && comparePart.StartsWith(part))).ToList();
    	}
    }
