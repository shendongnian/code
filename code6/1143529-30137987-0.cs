    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var str = Console.ReadLine();
    		var tokens = str.Split(' ');
    		var result = tokens.Select(t => Convert.ToInt32(t)).Aggregate(0, (s, t) => s + t);
    		Console.WriteLine(result);
    	}
    }
