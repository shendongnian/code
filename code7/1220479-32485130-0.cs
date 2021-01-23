    var query = usages.GroupBy(r => new { r.Alias, r.Date },
                               (key, elements) => new { key.Alias,
                                                        key.Date,
                                                        Count = elements.Count())
                      .OrderBy(x => x.Alias)
                      .ThenBy(x => x.Date);
    foreach (var item in query)
    {
        Console.WriteLine("{0} {1} {2}", item.Alias, item.Date, item.Count);
    }
