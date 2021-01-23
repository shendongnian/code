    var uniqStates = dbContext.conflocations.GroupBy(item => item.StateId)
                              .Select(x => new 
                                      {
                                          StateId = x.Key,
                                          Count = x.Count()
                                      });
