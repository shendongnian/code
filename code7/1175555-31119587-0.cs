    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string data = "Method,\"value1,value2\",Method2";
    		string[] pieces = Regex.Split(data, ",|(\"[^\"]*\")").Where(exp => !String.IsNullOrEmpty(exp)).ToArray();
    		
    		foreach (string piece in pieces)
    		{
    			Console.WriteLine(piece);
    		}
    	}
    }
