    var result = db.DocumentTable.GroupBy(t => t.Name)
                                 .Select(g => new {
                                                Name = g.Key,
                                                Count = g.Count()
                                              }
                                        );
