    var zone = DateTimeZoneProviders.Tzdb["America/Chicago"];
    var instantStart = Instant.FromDateTimeUtc(week.BeginDate);
    var chicagoStart = instantStart.InZone(zone);
    var localEnd = chicagoStart.LocalDateTime.PlusWeeks(weekCount);
    var chicagoEnd = localEnd.InZoneLeniently(zone);
    var bclEnd = chicagoEnd.ToDateTimeUtc();
    var result = repository
        .Fetch(x => x.BeginDate >= week.BeginDate && x.BeginDate < bclEnd)
        .OrderBy(x => x.RetailerWeekNumber)
        .ToList();
