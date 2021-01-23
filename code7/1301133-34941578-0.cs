    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static List<string> characters = new List<string>();
    	public static void Main()
    	{
    		var str = Regex.Replace("§My string 123”˝", "[^\u0020-\u007E]", Repl);//""
    		Console.WriteLine(str); // => My string 123
    		Console.WriteLine(string.Join(", ", characters)); // => §, ”, ˝
    	}
    	
    	public static string Repl(Match m)
    	{
    		characters.Add(m.Value);
    		return string.Empty;
    	}
    }
