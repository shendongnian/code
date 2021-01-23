     ar results = dt.AsEnumerable()
                    .Select(r => new
                              {
                                   LotNo = r.Field<int>("LotNo"),
                                   Level = r.Field<int>("Level"),
                                   IsValid = r.Field<string>("IsValid")
                              })
                     .GroupBy(x => new
                              {
                                   x.LotNo,
                                   x.Level
                              })
                      .Select(g => new
                              {
                                   g.Key.LotNo,
                                   g.Key.Level,
                                   Average = (double) g.Count(x => x.IsValid.ToLower() == "true")/g.Count()
                              });
                                            
      foreach (var result in results)
      {
          Console.WriteLine($"{result.Level}-{result.LotNo} : {result.Average * 100}");
      }
