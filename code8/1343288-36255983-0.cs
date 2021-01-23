    public object ConvertDate(DateTime inputTime, string fromOffset, string toZone)
    {
        // Ensure that the given date and time is not a specific kind.
        inputTime = DateTime.SpecifyKind(inputTime, DateTimeKind.Unspecified);
        var fromTimeOffset = new TimeSpan(0, - int.Parse(fromOffset), 0);
        var to = TimeZoneInfo.FindSystemTimeZoneById(toZone);
        var offset = new DateTimeOffset(inputTime, fromTimeOffset);
        var destination = TimeZoneInfo.ConvertTime(offset, to); 
        return destination.DateTime;
    }
