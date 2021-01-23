    var missing = points.GroupBy(p => p.ts_utc)
                        .SelectMany(g => desc.Where(d => g.All(p => p.type != d.type))
                                              .Select(d => new 
                                                           { 
                                                               ts = g.Key, 
                                                               type = d.type 
                                                           }));
