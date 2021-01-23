    using System;
    using System.Text.RegularExpressions;
					
    public class Program
    {
    	public static void Main()
    	{
		    // \s : Matches a space
		    // t : Exact match t
		    // \d{2} : Any digit, 2 repetition
		    // t : Exact match b
		    // \d{2} : Any digit, 2 repetition
		    var match = Regex.Match("I want to find t56b45 in a string", @".*(?=\st\d{2}b\d{2})");
		
		    if(match.Success)
		        Console.WriteLine("\"" + match.Value + "\"");
		    else
			    Console.WriteLine("Nothing found.");
            // Outputs: "I want to find"
    	}
    }
