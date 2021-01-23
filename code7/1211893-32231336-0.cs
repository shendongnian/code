    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string data = "AB123456789C123412341234B123";
    		string[] pieces = Regex.Split(data, "(?<=[a-zA-Z])|(?=[a-zA-Z])");
    		foreach (string p in pieces)
    			Console.WriteLine(p);
    	}
    }
