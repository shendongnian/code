    // ***
    // *** Geo coordinates of Benton Harbor/Benton Heights in Michigan
    // ***
    TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById (" Eastern Standard Time");              
    SolarTimes solarTimes = new SolarTimes(DateTime.Now, 42.1543, -86.4459);
    DateTime sunset = TimeZoneInfo.ConvertTimeFromUtc(solarTimes.Sunset.ToUniversalTime(), est);
    // ***
    // *** Display the sunset
    // ***
    Console.WriteLine("View the sunset across Lake Michigan from Benton Harbor Michigan at {0} on {1}.", sunset.ToLongTimeString(), sunset.ToLongDateString());
