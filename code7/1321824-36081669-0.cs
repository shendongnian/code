    static public itDateTime FixUTCUsingTimeZone(TimeZoneInfo oTimeZone, itDateTime oDateTime)
    {
        if (oDateTime == null || oTimeZone == null)
            return oDateTime;
        DateTime oTime = DateTime.SpecifyKind(oDateTime.Value, DateTimeKind.Unspecified);
        DateTime oResult = TimeZoneInfo.ConvertTimeFromUtc(oTime, oTimeZone);
        return new itDateTime(oResult);
