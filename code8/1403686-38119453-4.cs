    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Test($"{DateTime.Now}");
    	}
    	
    	public static void Test(object o) { Console.WriteLine("object"); }
    	public static void Test(string o) { Console.WriteLine("string"); }
    	public static void Test(IFormattable o) { Console.WriteLine("IFormattable"); }
    	// public static void Test(FormattableString o) { Console.WriteLine("FormattableString"); }
    }
