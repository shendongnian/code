    _entityContext.Statistics
    .ToList()
    .GroupBy(s => new 
    {
        s.Type, 
        Date = s.Date.Date
    })
    .Select(s=>new
    {
        Type=s.Key.Type, 
        Date = s.Key.Date, 
        Count = s.Count()
    });
