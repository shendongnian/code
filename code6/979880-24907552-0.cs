    string CountryCode = "IN";
    
                    var CountryInfo = (from location in TzdbDateTimeZoneSource.Default.ZoneLocations
                                       where location.CountryCode.Equals(CountryCode,
                                                  StringComparison.OrdinalIgnoreCase)
                                       select new { location.ZoneId, location.CountryName })
                     .FirstOrDefault();
    
                    var TimeZone = DateTimeZoneProviders.Tzdb[CountryInfo.ZoneId];
                    DateTime objdate = Instant.FromDateTimeUtc(DateTime.UtcNow)
                              .InZone(TimeZone)
                              .ToDateTimeUnspecified();
