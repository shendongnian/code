    public DateTime GetDate(
         DateTime start = default(DateTime), 
         DateTime end = default(DateTime))
    {
         start = start == default(DateTime) ? DateTime.MinValue : start;
         end = end == default(DateTime) ? DateTime.MinValue : end;
    }
