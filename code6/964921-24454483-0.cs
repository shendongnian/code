    using System;
    using System.Linq;
    using System.Reflection;
    			
    public class Program
    {
    	public static void Main()
    	{
    		String input = "\"thing 1\" \"thing 2\" \"thing 3\" \"thing 4\"";
    		var result = input.Split(new char[]{'\"'}).Where(p=> !String.IsNullOrWhiteSpace(p));
    		foreach(string v in result)
    			Console.WriteLine(v);
    	}
    }
