    public static int CountDays(IEnumerable<TimeRange> periods)
    {
        var usedDays = new Dictionary<DateTime, bool>();
        foreach (var period in periods)
            for (var day = period.Start; day <= period.End; day += TimeSpan.FromDays(1))
                usedDays[day] = true;
        return usedDays.Count(day => day.Value);
    }
