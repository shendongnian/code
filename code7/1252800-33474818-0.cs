    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{ 
            double[] HousePriceInDollars = { 3.4, 5.2, 1.2, 0.7, 2.6, 2.7, 3.0 };
          
    		var query =
    			from n in HousePriceInDollars
    			select n * 8;
    		
    		foreach (var item in query)
    			Console.WriteLine(item);
        }
    }
