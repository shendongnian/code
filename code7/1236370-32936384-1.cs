    public static DateTime AddTimeSpan(DateTime baseDateTime, TimeSpan ts, int multiplier)
    {
        var ticks = ts.Ticks;
        var duration = TimeSpan.FromTicks(ticks * multiplier);
        return baseDateTime.Add(duration);
    }
    //and use in select
    TimeSpan ts = new TimeSpan(2, 00, 0);
    List<DateTime> lstdt = dates.Select((d, idx) => AddTimeSpan(d, ts, idx + 1)).ToList();
