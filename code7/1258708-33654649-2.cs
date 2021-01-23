    var result = query.ToList().Select(p =>
        new
        {
            p.User,
            Date = new DateTime(p.Year.Value, p.Month.Value, p.Day.Value),
            p.Count
        }).ToList();
