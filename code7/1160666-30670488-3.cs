    string[] filterlist = Regex
                       .Matches(sfilter, @"(?<match>\w+)|\""(?<match>[\w\s]*)""")
                       .Cast<Match>()
                       .Select(m => m.Groups["match"].Value)
                       .ToArray();
    var query= ctx.INVENTORY.AsQueryable();
    if (filterList!=null && filterList.Any())
    {
      query=query.Where(i=>filterList.Any(fl=>i.Contains(fl));
    }
    var stk = await query.ToListAsync<INVENTORY>();
