    public static TimeSpan? TryGetTimeSpan(this string timeSpan, IFormatProvider formatProvider = null)
    {
        if (timeSpan == null) throw new ArgumentNullException("timeSpan");
        TimeSpan ts;
        bool success = TimeSpan.TryParse(timeSpan, formatProvider, out ts);
        if (success) return ts;
        return null;
    }
    public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
    {
        TimeSpan sum = TimeSpan.Zero;
        foreach (TimeSpan ts in timeSpans) sum = sum + ts;
        return sum;
    }
