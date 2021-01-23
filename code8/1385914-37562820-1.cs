       var result = collection.GroupBy(y => y.MsfId)
                        .Select(y => new SampleObject
                        {
                            MsfId = y.Key,
                            PgId = y.SelectMany(g => g.PgId).Distinct().ToList(),
                        }).ToList();
