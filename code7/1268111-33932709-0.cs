    public static string ToZoneString(this DateTimeOffset date, string zoneId, string formatter)
    {   
        //in this case all goes well
        //TimeZoneInfo zone = TimeZoneInfo.FindSystemTimeZoneById(zoneId);
        //return TimeZoneInfo.ConvertTime(date, zone).ToString(formatter); 
        //in this case an unexpected error occurs        
        return date.DateTime.ToZoneString(zoneId, formatter);
    }
