    _entityContext.Statistics
    .GroupBy(s => new 
    {
        s.Type, 
        Date = s.Date.Date
    })
    .Select(s=>new
    {
        Type=s.Key.Type, 
        Date = s.Date, 
        Count = s.Count()
    });
