    using System;
    using System.Web;
    public class Test
    {
    	public static void Main()
    	{
    		string s = "Get 50% off on Pizzas between 11am &amp;ndash; 5pm.";
    		Console.WriteLine(s);
		
    		string d = HttpUtility.HtmlDecode(s);
    		Console.WriteLine(d);
		
    		string e = HttpUtility.HtmlDecode(d);
    		Console.WriteLine(e);
    	}
    }
