    public List<DateTime> GetDates()
    {
        return db.Customers
          .ToList()
          .Select(pair =>
                 Enumerable.Range(0,(int)(pair.EndDate - pair.StartDate).TotalDays+1)
                           .Select(days => pair.StartDate.AddDays(days)))
          .SelectMany(x=>x)
          .Distinct();
    }
