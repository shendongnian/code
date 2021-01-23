    var result= list.GroupBy(item => item.Name)
                    .Select(group => new 
                    { 
                        Name = group.Key,
                        Values = group.GroupBy(item => item.Age)
                                      .Select(innerGroup => new 
                                      { 
                                          Age = group.Key, 
                                          Values = group.ToList() 
                                      }).ToList()
                    }).ToList();
