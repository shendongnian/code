    using NodaTime;
    using NodaTime.Text;
    
    // your inputs
    string time = "4:30pm";
    string timezone = "America/Chicago";
    
    // parse the time string using Noda Time's pattern API
    LocalTimePattern pattern = LocalTimePattern.CreateWithCurrentCulture("h:mmtt");
    ParseResult<LocalTime> parseResult = pattern.Parse(time);
    if (!parseResult.Success) {
        // handle parse failure
    }
    LocalTime localTime = parseResult.Value;
    
    // get the current date in the target time zone
    DateTimeZone tz = DateTimeZoneProviders.Tzdb[timezone];
    IClock clock = SystemClock.Instance;
    Instant now = clock.Now;
    LocalDate today = now.InZone(tz).Date;
    
    // combine the date and time
    LocalDateTime ldt = today.At(localTime);
    
    // bind it to the time zone
    ZonedDateTime result = ldt.InZoneLeniently(tz);
