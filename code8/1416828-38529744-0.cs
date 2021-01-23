    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var inputs = new string[] { "1, 2, 3", "1, myword, 3", "1, MyWord, 3" };
    		var pat = @"^\s*((?:\d+|myword)(\s*,\s*(?:\d+|myword))*)?\s*$";
            foreach (var s in inputs)
            	Console.WriteLine("{0} matched: {1}", s, Regex.IsMatch(s, pat, RegexOptions.IgnoreCase));
    	}
    	
    }
