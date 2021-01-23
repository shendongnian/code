    var dateString = "8/20/2014 6:00:00 AM";
    DateTime date1 = DateTime.Parse(dateString, 
                          System.Globalization.CultureInfo.InvariantCulture);
    var currentTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
    
    var utcDate = TimeZoneInfo.ConvertTimeToUtc(date1, currentTimeZone);
