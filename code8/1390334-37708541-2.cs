    public static TimeZoneInfo ToSystemTimeZone(this TimeZoneInfo customTimeZone)
    {
        var tz = TimeZoneInfo.GetSystemTimeZones().FirstOrDefault(x => x.HasSameRules(customTimeZone));
        if (tz != null) return tz;
        else return customTimeZone;
    }
