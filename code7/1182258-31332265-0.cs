    using System;
    using System.Text;
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
    		string input = "10:131186;";
    		MatchCollection mCol = Regex.Matches(input, "\\d+");
    		
    		StringBuilder sb = new StringBuilder();
    		foreach (Match m in mCol)
    		{
    			sb.Append(m.Value);
    		}
    		
    		Console.WriteLine(sb);
    	}
    }
