    var zone = DateTimeZoneProviders.Tzdb["America/Chicago"];
    var bclEnd = Instant.FromDateTimeUtc(week.BeginDate)
        .InZone(zone)
        .LocalDateTime
        .PlusWeeks(weekCount)
        .InZoneLeniently(zone)
        .ToDateTimeUtc();
