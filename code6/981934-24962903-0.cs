    IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
    {
        for (DateTime i = start; i < end; i = i.AddDays(1))
        {
            yield return i;
        }
    }
    
    var weekends = GetDaysBetween(DateTime.Today, DateTime.Today.AddDays(365))
        .Where(d => d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday);
