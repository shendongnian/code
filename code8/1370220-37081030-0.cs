    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
        	var s1 = "[0][1][2][0][9]";
        	var res1 = string.Join(",", GetNumbers(s1).ToList());         // Many
        	Console.WriteLine(res1);
        	Console.WriteLine(string.Join(",", GetNumbers("[8]").ToList())); // One
        	Console.WriteLine(string.Join(",", GetNumbers("").ToList())); // Empty
    	}
    	public static IEnumerable<int> GetNumbers(string text)
    	{
    		if (string.IsNullOrWhiteSpace(text))
    	        return Enumerable.Empty<int>();                    // No text => return Empty
    	    var match = Regex.Match(text, @"^(\[[0-9]+\])*$");
    	    if (!match.Success)                                    // No match => return Empty
    	        return Enumerable.Empty<int>();
    	    return match.Groups[1].Captures
                .Cast<Capture>()                                   // Get the captures
                .Select(n => Int32.Parse(n.Value.Trim('[', ']'))); // Trim the brackets and parse
    	}
    }
