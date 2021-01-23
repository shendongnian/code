    toto = db.companyDBSET                                    
        .GroupByPair(p => p.Founded_Year, myGroupingProperty)
        .Select(g => new timelineResult
        { 
            year = g.Key.Key1,
            cluster = g.Key.Key2.ToString(),
            count = g.Count()
        })
        .OrderBy(o => o.year)
        .ToList();
