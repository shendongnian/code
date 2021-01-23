    static TimeZoneInfo GetSeoulTimeZoneInfo()
    {
        try
        {
            // it raise System.TimeZoneNotFoundException in Unity 
            return TimeZoneInfo.FindSystemTimeZoneById("Korea Standard Time");
        }
        catch (System.TimeZoneNotFoundException)
        {
            const string timezoneId = "Korea Standard Time For Unity";
            var baseUtcOffset = TimeSpan.FromHours(9);
            const string displayName = "(UTC+09:00) 서울";
            const string standardDisplayName = "UTC+09";
            return TimeZoneInfo.CreateCustomTimeZone(timezoneId, baseUtcOffset, displayName, standardDisplayName);
        }
    }
