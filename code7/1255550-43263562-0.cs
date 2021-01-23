    /* 1. Sort the list and take the first */
    
    DateTime?[] dates = {dt1, dt2, dt3, dt4};
    
    dates.Sort (New NullableDateTimeComparer);
    return dates(0);
    /* Then later */    
    public class NullableDateTimeComparer : IComparer<DateTime>
    {
      public new int IComparer(DateTime x, DateTime y)
      {
        return DateTime.Compare(x.GetValueOrDefault(DateTime.MaxValue), .GetValueOrDefault(DateTime.MaxValue);
      }
    }
    
    /* 2. Write a custom function that takes the minimum if you must: */
    
    DateTime?[] dates = {dt1, dt2, dt3, dt4};
    return MinDate(dates);
    /* Then Later */
    
    static public DateTime? MinDate(DateTime?[] dates)
    {
      DateTime? min;
      for (int i = 0; i < dates.Length; ++i)
        if (dates[i].GetValueOrDefault(DateTime.MaxValue) < min.GetValueOrDefault(DateTime.MaxValue))
          min = dates[i];
      return min;
    }
