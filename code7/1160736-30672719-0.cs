    using System;
    using System.Text.RegularExpressions;    		
    					
    public class Program
    {
    	public static void Main()
    	{
    		int count = 0;
    		var b = Regex.Replace("gooodbaaad", "[oa]", m=> { count++; return "x"; });
    		
    		Console.WriteLine(b);
    		Console.WriteLine(count);    		
    	}
    }
