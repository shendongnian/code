    public static DateTimeOffset GetDTOFromLocalAndUTC(DateTime localTime, DateTime? utcTime)
    {
        int documentDateOffset = 0;
        DateTimeOffset result;
        if (utcTime.HasValue)
        {
            documentDateOffset = ((TimeSpan)(localTime - utcTime.Value)).Hours;
        }
        result = new DateTimeOffset(localTime, TimeSpan.FromHours(documentDateOffset));
        return result;
    }
