    var result = baseSource.GroupBy(x => x.Name)
                    .Select(x =>
                    {
                        var orderedObj = x.OrderByDescending(z => z.Version)
                                          .ThenByDescending(z => z.abc).FirstOrDefault();
                        return new 
                                {
                                     PK = orderedObj.PK,
                                     Name = x.Key,
                                     Version = orderedObj.Version ,
                                     abc = orderedObj.abc
                                 };
                    };
