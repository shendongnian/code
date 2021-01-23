    var results = context.Entries
        .Include(x => x.Contract)
        .GroupBy(t=>t.Contract)
        .Select(t=>new{
            Contract=t.Key,
            Years=t.GroupBy(s=>s.Year)
                .Select(s=>new{
                   Year=s.Key,
                   Count=s.Count()
                }).ToDictionary(t=>t.Year,t=>t.Count)
            })
         .Take(5);
