    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    
    public class Test
    {
    	public static void Main()
    	{
    		var strs = new List<string> { "test    35,1    35,2    35,3    35,4    35,5",
    		"test2   35,1    35,2    35,3    35,4    35,5",
    		"test3   35,1    35,2    35,3    35,4    35,5",
    		"test    35,1    35,2    35,3    35,4    35,5",
    		"test2   35,1    35,2    35,3    35,4    35,5",
    		"test3   35,1    35,2    35,3    35,4    35,5"};
    		
    		var pattern = @"(?<key>test\d*)\b(?>\s*(?<test>\d+(?:,\d+)*))+";
    		foreach (var s in strs)
    		{
    		    var match = Regex.Match(s, pattern, RegexOptions.ExplicitCapture);  
    		    if (match.Success) 
    		    {                     // DEMO
    		    	var key = match.Groups["key"].Value;
    		    	var tests = match.Groups["test"].Captures.Cast<Capture>().Select(m => m.Value).ToList();
    		        Console.WriteLine(key);
    		        Console.WriteLine(string.Join(", and ", tests));
    		    }
    		}
    	}
    }
