    var tz = "Eastern Standard Time"; // local time zone
    var timeZone = TimeZoneInfo.FindSystemTimeZoneById(tz);
    var localTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
    //Console.WriteLine(localTime.ToString("G"));
    //Console.ReadLine();
