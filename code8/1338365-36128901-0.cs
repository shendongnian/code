    static public List<DateTime> GetDates(DateTime start_date, DateTime end_date)
    {
     return Enumerable.Range(0, (int)((end_date- start_date).TotalDays) + 1)
                      .Select(n => StartDate.AddDays(n))
					  .Where(x=>x.DayOfWeek == DayOfWeek.Saturday 
                             || x.DayOfWeek == DayOfWeek.Sunday)
                      .ToList();
    }
