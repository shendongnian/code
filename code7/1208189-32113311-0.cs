    var result = items.GroupBy(x => x.Id)
                      .Select(x => 
                      {
                         var CriteriaObj = x.OrderByDescending(z => z.MajorV)
                                            .ThenByDescending(z => z.MinorV).First();
                         return new ObjX
                                {
                                    Id = x.Key,
                                    MajorV = CriteriaObj.MajorV,
                                    MinorV = CriteriaObj.MinorV
                                };
                      }).ToList();
