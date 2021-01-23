    using System;
    using System.Globalization;
					
    public class Program
    {
	public static void Main()
	{
		double amount = 39.50;
		
		Console.WriteLine("Hello World");
		Console.WriteLine(string.Format(new CultureInfo("en-US"),"{0:C1}",  amount));
	}
    }
