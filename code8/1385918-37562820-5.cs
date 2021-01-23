    var collection2 = new List<SampleObjectSource>();
    var result1 = collection2.GroupBy(y => y.MsfId)
                  .Select(y => new SampleObject
                  {
                      MsfId = y.Key,
                      PgId = y.Select(h => h.PgId).Distinct().ToList(),
                  }).ToList();
