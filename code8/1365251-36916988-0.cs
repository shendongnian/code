    var query = Enumerable.Range(0, 24)
        .Select(h => new 
        { 
            Number = h, 
            Count = newLeads.Count(nl => nl.CreateDate.Hour == h) 
        })
        .Select(x => new { x.Number, Times = x.Count == 0 ? 1 : x.Count });
 
