    var results = context.Entries
        .Include(x => x.Contract)
        .GroupBy(t=>t.Contract)
        .Select(t=>new{
            Contract=t.Key,
            Years=t.GroupBy(s=>s.Year)
                .Select(s=>new{
                   Year=s.Key,
                   Count=s.Count()
                })
            })
         .Take(5);
