    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;
    public class Test
    {
    	public static string num = string.Empty;
    	public static void Main()
    	{
    		var s = "work 1 work 2 work 3 work 4 work 5";
            Console.WriteLine(Regex.Replace(s, @"work (?<num>\d+)", Repl));
    	}
    	
    	public static string Repl(Match m)
    	{
    		num = m.Groups["num"].Value + num;
    		return string.Format("work {0}", num);
    	}
    }
