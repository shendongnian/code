    var hourlyLeads = Enumerable.Range(0, 24)
        .Select(h => new 
        { 
            Hour = h, 
            Count = newLeads.Count(nl => nl.CreateDate.Hour == h) 
        })
        .Select(x => new 
        { 
            Number = x.Hour, 
            Times = x.Count == 0 ? 1 : x.Count
        })
        .ToList();
 
