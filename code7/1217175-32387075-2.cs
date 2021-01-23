    var groupItems = MyList.GroupBy(g => g.Id)
                            .Where(w => w.Any(a => a.Code == 1)
                            .Select(s => new 
                                        { key = s.Key, 
                                          items = s.OrderBy(o => o.Item1)
                                                   .ThenBy(t => t.Item2)
                                         }
                                    )
                                    .OrderBy(o => o.Id)
                                    .SelectMany(sm => sm.Items)
                      .Union(MyList.GroupBy(g => g.Id)
                            .Where(w => w.Any(a => a.Code == 2)
                            .Select(s => new 
                                        { key = s.Key, 
                                          items = s.OrderBy(o => o.Item1)
                                                   .ThenBy(t => t.Item2)
                                         }
                                    )
                                    .OrderBy(o => o.Id)
                                    .SelectMany(sm => sm.Items)).ToList();
