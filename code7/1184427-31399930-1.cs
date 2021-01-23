    using System;
    
    class Program
    {
        static void Main()
        {
    	TimeZone zone =  TimeZone.CurrentTimeZone;
    	// Demonstrate ToLocalTime and ToUniversalTime.
    	DateTime local = zone.ToLocalTime(DateTime.Now);
    	DateTime universal = zone.ToUniversalTime(DateTime.Now);
    	Console.WriteLine(local);
    	Console.WriteLine(universal);
        }
    }
