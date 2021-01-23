    public static int CountDays(IEnumerable<TimeRange> periods)
    {
        var usedDays = new HashSet<DateTime>();
        foreach (var period in periods)
            for (var day = period.Start; day <= period.End; day += TimeSpan.FromDays(1))
                usedDays.Add(day);
        return usedDays.Count;
    }
