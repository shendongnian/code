    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		List<string> s = new List<string>() { "a", "b", "c", "a"};
    		var asc = s.OrderBy(e => e).ToList<string>();
    		Console.WriteLine(string.Join(", ", asc));
    	}
    }
