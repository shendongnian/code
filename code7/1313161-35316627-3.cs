    var zonesByCountryCode = TzdbDateTimeZoneSource.Default
       .ZoneLocations
       .GroupBy(loc => loc.CountryCode)
       .Where(g => g.Count() == 1) // Single-zone countries only
       .ToDictionary(g => g.Key, g => g.First());
