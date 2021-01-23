    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		DateTime currDate = DateTime.MinValue;
    		DateTime.TryParseExact("31 March 2015", "dd MMMM yyyy", null, System.Globalization.DateTimeStyles.None, out currDate);
    		Console.WriteLine(currDate);
    	}
    }
