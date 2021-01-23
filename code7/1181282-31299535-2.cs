    var query = codes.Select(c => 
        new
        {
            SplitArray = c.Split('.'),  //to avoid multiple split
            Value = c
        })
        .Select(c => new
        {
            Prefix = c.SplitArray.First(), //you can avoid multiple split if you split first and use it later
            PostFix = c.SplitArray.Last(),
            Value = c.Value,
        })
        .GroupBy(r => r.Prefix)
        .Select(grp => new
        {
            Key = grp.Key,
            Items = grp.Count() > 1 ? String.Join(",", grp.Select(t => t.PostFix)) : "",
            Value = grp.First().Value,
        });
