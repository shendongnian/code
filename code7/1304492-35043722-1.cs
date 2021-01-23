    TimeZoneInfo easternZone;
    try
    {
        easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    }
    catch (TimeZoneNotFoundException)
    {
        easternZone = TimeZoneInfo.FindSystemTimeZoneById("America/New_York");
    }
