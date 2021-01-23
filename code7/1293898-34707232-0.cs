    var result = tablo.AsEnumerable().
                      .GroupBy(row => new 
                                { 
                                   X= row.Field<string>("X"), 
                                   Y = row.Field<string>("Y") 
                                })
                      .Select(x => new 
                                  {
                                     X = x.Key.X,
                                     Y = x.Key.Y,
                                     P = x.Max(z => z.Field<int>("P"))
                                  });
