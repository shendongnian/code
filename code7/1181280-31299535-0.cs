    var query = codes.Select(c => new
    {
        Prefix = c.Split('.').First(), //you can avoid multiple split if you split first and use it later
        PostFix = c.Split('.').Last(),
        Value = c,
    })
        .GroupBy(r => r.Prefix)
        .Select(grp => new
        {
            Key = grp.Key,
            Items = grp.Count() > 1? String.Join(",", grp.Select(t => t.PostFix)) : "",
            Value = grp.First().Value,
        });
