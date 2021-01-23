    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    public class Test
    {
    	public static void Main()
    	{
    		var str = "Please write a program that breaks this text into small chucks. Each chunk should have a maximum length of 25 ";
    		var chunks = Regex.Matches(str, @"(\b.{1,25})(?:\s+|$)")
    		         .Cast<Match>().Select(p => p.Groups[1].Value)
    		         .ToList();
    		Console.WriteLine(string.Join("\n", chunks));
    	}
    }
