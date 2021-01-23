    var result = context.PartValues
        .GroupBy(x => new
        {
            Date = DbFunctions.TruncateTime(x.DateAdded), //Extract Date only (time part is 0)
            Hour = x.DateAdded.Hour
        }).Select(g => new
        {
            g.Key.Date,
            g.Key.Hour,
            Total = g.Count()
        })
        .ToList();
