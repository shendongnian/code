    var result = list.GroupBy(a => a)
                            .Select(g => new
                            {
                                Number = g.Key,
                                Total = g.Count()
                            })
                            .OrderBy(g => g.Total).FirstOrDefault();
