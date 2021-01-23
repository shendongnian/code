    groupItems =   MyList.GroupBy(g => g.Id)
                            .Where(w => codes.Contains(w.Code))
                            .Select(s => new 
                                        { key = s.Key, 
                                          items = s.OrderBy(o => o.Item1)
                                                   .ThenBy(t => t.Item2)
                                         }
                                    )
                                    .OrderBy(o => o.Key)
                                    .SelectMany(sm => sm.Items);
