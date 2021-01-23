    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void WithRegex(string test)
    	{
    		string extracted = new Regex(@"- ?(.*) ?\([^\(]+$").Match(test).Groups[1].Value;
    		Console.WriteLine("Extracted: {0}", extracted);
    	}
    	
    	public static void WithoutRegex(string test)
    	{
    		string extracted = test.Substring(test.IndexOf("-") + 1, test.LastIndexOf("(") - test.IndexOf("-") - 1).Trim();
    		Console.WriteLine("Extracted: {0}", extracted);
    	}
    	
    	public static void Main()
    	{
    		string test = "item_id - description (something else) !onuth - hi you (moreInfo)";
    		WithRegex(test);
    		WithoutRegex(test);
    	}
    }
