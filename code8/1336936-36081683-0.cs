    DateTime start = new DateTime(2016, 1, 1);
    DateTime end = new DateTime(2016, 1, 4);
    Enumerable
        .Range(0, 1 + (end - start).Days)
        .Select(x => start.AddDays(x))
        .GroupJoin(Set.SelectMany(u => u.Orders),
            dt => dt, o => o.Date,
            (dt, orders) => new OrderDateSummary { Date = dt, Total = orders.Count() })
        .ToList();
