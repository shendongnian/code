    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<string> data = new List<string>()
    		{
    			"18-may 123 my name",
    			"my name 18-may 1234",
    			"134 my name 18-may"
    		};
    		
    		foreach (string d in data)
    		{
    			int year;
    			string[] pieces = d.Split(' ')
    				.Where(p => int.TryParse(p, out year)).ToArray();
    			foreach (string piece in pieces)
    			{
    				Console.WriteLine(piece);
    			}
    		}
    	}
    }
