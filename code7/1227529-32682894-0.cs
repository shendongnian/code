    var startTime = Convert.ToDateTime(start);
    var endTime = Convert.ToDateTime(end);
    IEnumerable<T> prices= new List<T>();  // whatever T is
    IEnumerable<T> cht;
    var currentFetched = 0;
    do
    {
        cht = _db.TickerData.Where(p => p.Time >= startTime && p.Time << endTime)
                            .OrderBy(p => p.Time)
                            .Skip(processed)
                            .Take(1000)
                            .ToList();
        currentFetched = cht.Count();
        
        // prices = prices.Concat(cht).ToList();  
        // ^ This might throw an exception later when the list becomes too big 
        // So you can probably process currently fetched data
    }
    while (currentFetched > 0);
    
