    using System;
					
    public class Program
    {
	    public static void Main()
	    {
		
		    DateTime checkIn = new DateTime(2016, 8, 31);
		    DateTime checkOut = new DateTime(2016, 9, 1);
		
		    TimeSpan difference = checkOut - checkIn;
		
		    Console.WriteLine(difference);
		
	    }
    }
