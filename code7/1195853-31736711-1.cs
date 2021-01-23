    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string html = "<br />\n" +
    			"Your coupon for 50% off MSRP - Inline is: XXXXXXXXXXX<br />" +
    			"Your coupon for 50% off MSRP - Outdoor is: XXXXXXXXXXX<br /><br />";
    		
    		MatchCollection matches = Regex.Matches(html, ".*?coupon.*?(?<=: )(\\w+)(?=<br />|<br/>)");
    		foreach (Match match in matches)
    		{
    			Console.WriteLine(match.Groups[1]);
    		}
    	}
    }
