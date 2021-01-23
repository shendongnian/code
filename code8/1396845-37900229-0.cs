    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("Hello World");
    		DateTime timespan = DateTime.Parse("08:55 AM");  //gives us a DateTime object
    		DateTime timespan2 = DateTime.Parse("08:55 PM");
    	
            TimeSpan _time = timespan.TimeOfDay;  //returns a TimeSpan from the Time portion
    		TimeSpan _time2 = timespan2.TimeOfDay;
    		Console.WriteLine(_time);
    		Console.WriteLine(_time2);
    	}
    }
