    var subtotal = query.GroupBy(x=>x.BusinessTypeCode ).Select(s=>new BusRow
    {
        BusinessTypeCode =s.Key,
        BusL = s.Sum(x=>x.BusL),
        BusInterrest = s.Sum(x=>x.BusInterrest),
        BusAdmin = s.Sum(x=>x.BusAdmin),
        BusPenalty = s.Sum(x=>x.BusPenalty),
        TotalBusCollected = s.Sum(x=>x.TotalBusCollected),
    });
