    using System;
    using System.Text.RegularExpressions;
					
    public class Program
    {
    	public static void Main()
    	{
		
    		var match = Regex.Match("I want to find t56b45 in a string", @"^(?<text>.*)(\st[0-9]{2}b[0-9]{2})");
		
    		Console.WriteLine(match.Groups["text"]);
    	}
    }
