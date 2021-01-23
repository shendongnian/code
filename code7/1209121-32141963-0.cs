    var result = Data.GroupBy(x => x.Type)
                     .Select(x => new 
                            {
                                 TypeAB = x.Key,
                                 Obj = x.GroupBy(z => z.Date)
                                        .Select(z => new 
                                                {
                                                    Date = z.Key,
                                                    InnerObj = z.Select(i => new 
                                                                 {
                                                                     Id = i.Id,
                                                                     Name = i.Name,
                                                                     Count = i.Count
                                                                 })
                                                }).ToArray()
                           });
