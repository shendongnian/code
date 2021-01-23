    using System;
    using System.Text.RegularExpressions;
					
    public class Program
    {
    	public static void Main()
    	{
    		// (?<text>.*) : Match all characters, any repetition, in a group named text (until the rest of the Regex is found)
    		// \s : Matches a space
    		// t : Exact match t
    		// [0-9]{2} : Any digit, 2 repetitions
    		// t : Exact match b
    		// [0-9]{2} : Any digit, 2 repetitions
    		var match = Regex.Match("I want to find t56b45 in a string", @"(?<text>.*)\st[0-9]{2}b[0-9]{2}");
		
            if(match.Success)
		        Console.WriteLine(match.Groups["text"].Value);
		    else
			    Console.WriteLine("Nothing found.");
            // Outputs: "I want to find"
    	}
    }
