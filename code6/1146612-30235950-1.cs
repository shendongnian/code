    var result = table.AsEnumerable()
                      .GroupBy(r => r["colA"])
                      .ToDictionary(g => g.Key, 
                                    g => g.GroupBy(r => r["colB"])
                                          .ToDictionary (g2 => g2.Key, 
                                                         g2 => g2.Select(r => r["ColC"])
                                                                 .First()
                                                         )
                                    );
