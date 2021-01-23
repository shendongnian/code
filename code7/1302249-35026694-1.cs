    var summedData = data.GroupBy(r => new { r.user })
                         .Select(r => new Raport()
                                      {
                                          user = r.Key.user,
                                          xValue = r.Sum(innerR => innerR.xValue),
                                          yValue = r.Sum(innerR => innerR.yValue)
                                      }
                                 );
