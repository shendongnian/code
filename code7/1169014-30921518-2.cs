    private List<DateTime> FallBetween(SortedDictionary<DateTime, double> columns, DateTime activityDate)
    {
        var keys = new List<DateTime>(columns.Keys);
        int index = ~(keys.BinarySearch(activityDate));
        var dates = new List<DateTime>();
        try
        {
            dates.Add(keys[index]);
        } catch { }
        try
        {
            dates.Add(keys[index - 1]);
        } catch { }
        return dates;
    }
