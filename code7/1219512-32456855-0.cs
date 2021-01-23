    var result = context.Set<inspectionsData>()
                      .GroupBy(d => new {d.City, d.Authority})
                      .Select(g => new inspectionsData{
                                   City = g.Key.City, 
                                   Authority = g.Key.Authority, 
                                   Items = g.Sum(x => x.Items)})
                      .ToList();
