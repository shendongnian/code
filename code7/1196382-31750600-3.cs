    public List<DateTime> GetDates()
    {
    
        IEnumerable<Customers> Dates = dc.Customers
          .Where(d => d.StartDate.Value >= DateTime.Now);
    
        var FromDate = Dates.Where(f => f.StartDate.HasValue)
          .Min(f => f.StartDate).Value;
        var ToDate = Dates.Where(t => t.EndDate.HasValue)
          .Max(f => f.EndDate).Value;
    
        
        IEnumerable<DateTime> AllDates = Enumerable.Range(0, int.MaxValue)
                     .Select(x => FromDate.Date.AddDays(x))
                     .TakeWhile(x => x <= ToDate.Date)
                     .Where(x=>dc.Customers.Any(c=>x>=c.StartDate && x<=c.EndDate));
    
        return AllDates.ToList();
    }
