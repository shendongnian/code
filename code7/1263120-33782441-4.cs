    var data = modelData.Where(x => x.real.Equals(1))
                        .GroupBy(x => new { x.DT.Date, x.name });
    var byDate = modelData.Where(x => x.real.Equals(1))
                          .ToLookup(g => g.Key, g => g.ToList());
    foreach(var item in data)
    {
	    var aDate = item.Key.Date; 
	    var aName = item.Key.name;
	    var namesRealTrades = item.ToList();
        var dateRealTrades = byDate[aDate];
        // DO MY PROCESSING
    }
