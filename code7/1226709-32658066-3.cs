        DateTime utc = DateTime.UtcNow;
        TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        DateTime eastern = TimeZoneInfo.ConvertTimeFromUtc(utc, tz); 
    Or, with Noda Time and IANA time zone IDs:
        Instant now = SystemClock.Instance.Now;
        DateTimeZone tz = DateTimeZoneProviders.Tzdb["America/New_York"];
        ZonedDateTime eastern = now.InZone(tz);
    
