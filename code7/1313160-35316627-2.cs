    using NodaTime;
    using NodaTime.TimeZones;
    using System.Linq;
    ...
    var code = "TR"; // Turkey
    var zoneId = TzdbDateTimeZoneSource.Default.ZoneLocations
                                       .Single(loc => loc.CountryCode == code)
                                       .ZoneId;
    var zone = DateTimeZoneProviders.Tzdb[zoneId];
