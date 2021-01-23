    // You'd normally inject this instead, so that you can use a fake clock for
    // testing
    IClock clock = SystemClock.Instance;
    // Or you could use the TZDB provider, with the appropriate time zone ID
    var zone = DateTimeZoneProviders.Bcl["Australian Western Standard Time"];
    
    // What is the current time in the given time zone? The result retains the
    // time zone as well as the instant in time, but properties like Hour return
    // the *local* time in that time zone.
    var zonedDateTime = clock.Now.InZone(zone);
    // You may not need this at all - it depends on what you want to do
    var localDateTime = zonedDateTime.LocalDateTime;
