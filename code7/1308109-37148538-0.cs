    GeographicRegion userRegion = new GeographicRegion();
    string regionCode = userRegion.Code;
    
    Windows.Globalization.DateTimeFormatting.DateTimeFormatter dtf = new DateTimeFormatter("shortdate", new[] { regionCode }, regionCode, CalendarIdentifiers.Gregorian, ClockIdentifiers.TwentyFourHour);
            
    DateTimeOffset result = cdpStartDate.Date ?? DateTimeOffset.MinValue;
            
    string shortDate = dtf.Format(result);
