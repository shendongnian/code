    private static DateTime GetNextRun(DateTime lastRun)
    {
        var next = lastRun.AddDays(1);
        return new DateTime(next.Year, next.Month, next.Day, 9, 0, 0); 
    }
