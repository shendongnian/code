    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string line = "\"61402818083\",\"services\",\"in postcodes 3000, 4000\",\"are\",\"First Name\"";
    		Console.WriteLine(line.ToString());
    		var reg = new Regex("(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)", RegexOptions.Compiled);
    		var matches = reg.Matches(line);
    		foreach (Match match in reg.Matches(line))
    		{
    			Console.WriteLine(match.Value.TrimStart(','));
    		}
    	}
    }
