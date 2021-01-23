    var grouped = from d in sampleData
                    group d by d.Country
                    into g
                    select new {
                             Country = g.Key,
                             Data = g.Select(i => new {
                                                 Religion = i.Religion,
                                                 Population = i.Population
                                             })
                              };
