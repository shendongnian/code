    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
		    string myString = (720000.00).ToString();
		    Console.WriteLine(myString.Split('.')[0].Where(d => d == '0').Count());
    	}
    }
