    var dates = new DateTime[] { /* dates */ };
    var groups = dates.GroupBy(d => d.GetWeekOfYear()).Select(g => new 
    {
        Week = g.Key,
        Dates = g.ToArray(),
        Count = g.Count()
    });
