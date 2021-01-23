    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var s = "www.website-link.ch";
    		var builder = new UriBuilder(s);
    		if (builder.Scheme == Uri.UriSchemeHttps)
    		{
    			Console.WriteLine("String starts with `https`");
    		}
    		
    		Console.WriteLine("String does not start with `https`");
    	}
    }
