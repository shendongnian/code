    var finalResult=ConvertTimeZone(Datetime.UtcNow,"Central Standard Time");
 
    public DateTime ConvertTimeZone(DateTime dateTime, string timeInfo)
        {
            var result = OlsonTimeZoneToTimeZoneInfo(timeInfo);
            if (result != null)
            {
                var finalTimeZone = TimeZoneInfo.FindSystemTimeZoneById(result);
                dateTime = (dateTime != null ? TimeZoneInfo.ConvertTimeFromUtc(dateTime != null ? dateTime : DateTime.UtcNow, finalTimeZone) : DateTime.UtcNow);
            }
            return dateTime;
        }
