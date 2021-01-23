    var distinctDate = instances
        .GroupBy(e => e.StartDate.Date)
        .Select(grp => grp.First())
        .OrderyBy(e => e.StartDate.Date)
        .GroupBy(e => new { e.StartDate.Year, e.StartDate.Month });
