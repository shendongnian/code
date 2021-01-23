    DateTime dt = new DateTime(1972, 4, 24, 0, 0, 0);    
    TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    
    Console.WriteLine (TimeZoneInfo.ConvertTimeToUtc(dt, tz));
    // 4/24/1972 7:00:00 AM
