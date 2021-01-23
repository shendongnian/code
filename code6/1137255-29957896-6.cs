    var pacific = DateTimeZoneProviders.Tzdb["America/Los_Angeles"];
    
    LocalDateTime localDateTime = new LocalDateTime(1972, 4, 24, 0, 0);
    ZonedDateTime zonedDateTime = pacific.AtStrictly(localDateTime);
    
    DateTime utcDateTime = zonedDateTime.ToDateTimeUtc();
    
    Console.WriteLine(utcDateTime);
    // 4/24/1972 8:00:00 AM
