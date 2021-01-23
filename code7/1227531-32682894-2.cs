    var startTime = Convert.ToDateTime(start);
    var endTime = Convert.ToDateTime(end);
    IEnumerable<T> prices= new List<T>();  // whatever T is
    
    var currentFetched = 0;
    var totalFetched = 0;
    do
    {
        var cht = _db.TickerData.Where(p => p.Time >= startTime && p.Time << endTime)
                            .OrderBy(p => p.Time)
                            .Skip(totalFetched)
                            .Take(1000)
                            .ToList();
        currentFetched = cht.Count();
        totalFetched += currentFetched;
        
        // prices = prices.Concat(cht).ToList();  
        // ^ This might throw an exception later when the list becomes too big 
        // So you can probably process currently fetched data
    }
    while (currentFetched > 0);
    
