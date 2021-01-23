    public static DateTime TimetoEst(DateTime timenow)
    {
        var dto = new DateTimeOffset(timenow);  // will use .Kind to decide the offset
        var converted = dto.ToOffset(TimeSpan.FromHours(-5));
        return converted.DateTime;
    }
