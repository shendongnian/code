    var tzdb = DateTimeZoneProviders.Tzdb;
    var pattern = ZonedDateTimePattern.Create(
        "M/d/yyyy h:mmtt",
        CultureInfo.InvariantCulture,
        Resolvers.LenientResolver,
        tzdb,
        NodaConstants.UnixEpoch.InZone(tzdb["America/New_York"]));
    string text = "04/24/2015 4:00pm";
    
    var zoned = pattern.Parse(text).Value;
    Console.WriteLine(zoned);
