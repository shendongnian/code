    var query = context.tables.GroupBy(r=>new{r.Col3, r.Col4, r.Col5})
                              .Select(g=>{
                                             Col1 = g.Sum(c=>c.Col1),
                                             Col2 = g.Sum(c=>c.Col2),
                                             Col3 = g.Key.Col3,
                                             Col4 = g.Key.Col4,
                                             Col5 = g.Key.Col5,
                                             Col6 = g.Count
                                         })
