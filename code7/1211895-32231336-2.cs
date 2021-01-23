    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string data = "AB123456789C123412341234B123";
    		var pieces = Regex.Split(data, "(?<=[a-zA-Z])|(?=[a-zA-Z])").Where(p => !String.IsNullOrEmpty(p));
    		foreach (string p in pieces)
    			Console.WriteLine(p);
    	}
    }
