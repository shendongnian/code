    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string data = "Value1   Value2   \"Val ue3\"";
    		MatchCollection matchCollection = Regex.Matches(data, "\\w+|\"[\\w ]+\"");
    		foreach (Match match in matchCollection)
    		{
    			Console.WriteLine(match.Value.Replace("\"", String.Empty));
    		}
    	}
    }
