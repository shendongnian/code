    // You should use dependency injection really - that makes the code much more
    // testable. Basically, you want an IClock...
    IClock clock = SystemClock.Instance;
    var countryCode = "IN";
    var location = TzdbDateTimeZoneSource.Default
                     .FirstOrDefault(location => location.CountyCode == countryCode);
    if (location == null)
    {
        // This is up to you - there's no location with your desired country code.
    }
    else
    {
        var zone = DateTimeZoneProviders.Tzdb[location.ZoneId];
        var zonedNow = clock.Now.InZone(zone);
        // Now do what you want with zonedNow... I'd avoid going back into BCL
        // types, myself.
    }
