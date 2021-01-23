    using System.Linq;
    using System;
    
    public class Program
    {
    	public static void Main()
    	{
           string[] words = { "providerZip", "providerType" };
    		var res = words.Aggregate((current, next) => current + ", " + next);
    		Console.WriteLine(res);
          
    	}
    }
