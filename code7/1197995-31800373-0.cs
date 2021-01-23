    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string line = "\"61402818083\",\"services\",\"in postcodes 3000, 4000\",\"are\",\"First Name\"";
    		var reg = new Regex("\".*?\"");
    		var matches = reg.Matches(line);
    		foreach (var item in matches)
    		{
    			Console.WriteLine(item.ToString());
    		}
    	}
    }
