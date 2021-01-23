    public static double GetDurationForTimezone(DateTime startUtc, DateTime endUtc, string timezoneId)
    {
        var timezone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(timezoneId);
        // convert UTC to timezone
        var startInstantUtc = Instant.FromDateTimeUtc(startUtc);
        var startZonedDateTime = startInstantUtc.InZone(timezone);
        var startLocalDateTime = startZonedDateTime.LocalDateTime;
        var endInstantUtc = Instant.FromDateTimeUtc(endUtc);
        var endZonedDateTime = endInstantUtc.InZone(timezone);
        var endLocalDateTime = endZonedDateTime.LocalDateTime;
        return Period.Between(startLocalDateTime, endLocalDateTime, PeriodUnits.Seconds).Seconds;
    }
