    var tmp = array
       .GroupBy(item => item)
       .OrderByDescending(g => g.Count())
       .Select(g => new {
           Item = g.Key
       ,   Count = g.Count()
       }).ToList();
    var res = tmp
        .TakeWhile(p => p.Count == tmp[0].Count)
        .Select(p => p.Item)
        .ToList();
