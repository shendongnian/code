    DateTime utcTime = new DateTime(2016,2,10,10,15,00);
    var tz = TimeZoneInfo.FindSystemTimeZoneById("Your Time Zone");
    var tzTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tz);
    //To get time in UTC
    var utcTime = TimeZoneInfo.ConvertTimeToUtc(tzTime, tz);
