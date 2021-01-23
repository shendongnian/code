    var result = context.ServiceRequests.GroupBy(sr => sr.SR_Status)
        .Select(g => new { Key = g.Key, Count = g.Count() })
        .OrderByDescending(kv => kv.Count)
        .Take(5)
        .ToList();
