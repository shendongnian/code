    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<string> expressions = new List<string>
    		{
    			"2 + 3", 
    			"2 * 3", 
    			"2 / 3", 
    			"2 - 3" 
    		};
    		
    		Console.WriteLine("Before: ");
    		expressions.ForEach(Console.WriteLine);
    		Console.WriteLine();
    		
    		for (int i = 0; i < expressions.Count; i++)
    		{
    			string[] pieces = Regex.Split(expressions[i], "([-+/*])")
    				.Select((p, j) => j == 2 ? (2 * 0.03).ToString() : p.Trim())
    				.ToArray();
    			expressions[i] = String.Join(" ", pieces);
    		}
    		
    		Console.WriteLine("After: ");
    		expressions.ForEach(Console.WriteLine);
    		Console.WriteLine();
    	}
    }
