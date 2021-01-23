    public static NSDate DateTimeToNSDate(DateTime date)
    {
        return NSDate.FromTimeIntervalSinceReferenceDate((date - (new DateTime(2001, 1, 1, 0, 0, 0))).TotalSeconds);
    }
    public static DateTime NSDateToDateTime(NSDate date)
    {
        return (new DateTime(2001, 1, 1, 0, 0, 0)).AddSeconds(date.SecondsSinceReferenceDate);
    }
