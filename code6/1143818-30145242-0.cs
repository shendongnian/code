     DateTime utcTime = DateTime.UtcNow;
     string turkeyTimezoneKey = "Turkey Standard Time";
     try
     {
        TimeZoneInfo turkeyTimezone = TimeZoneInfo.FindSystemTimeZoneById(turkeyTimezoneKey);
         var turkeyTime = TimeZoneInfo.ConvertTimeToUtc(utcTime, turkeyTimezone);
     }
     catch (TimeZoneNotFoundException)
     {
     }  
