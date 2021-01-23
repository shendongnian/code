    using System;
    using System.Text.RegularExpressions;
					
    public class Program
    {
	    public static void Main()
    	{
            var result = Regex.Match("C 01 ABC 02 AB", @"^(.+)\s(\d+\s.+?\s\d+)\s(.+)");
		    Console.WriteLine(result.Groups[0].Value); // "C 01 ABC 02 AB"
	    	Console.WriteLine(result.Groups[1].Value); // "C"
    		Console.WriteLine(result.Groups[2].Value); // "01 ABC 02"
		    Console.WriteLine(result.Groups[3].Value); // "AB"
	    }
    }
