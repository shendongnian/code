    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string data = System.Net.WebUtility.HtmlDecode("Get 50% off on Pizzas between 11am &amp;ndash; 5pm"); 
    		
    		Console.WriteLine(data);
    	}
    }
