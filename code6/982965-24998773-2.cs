    results.GroupBy(r => r.Email).Select(g => new Record() 
                                  {
                                      Name = g.First().Name,
                                      Email = g.First().Email,
                                      TotalPoints = g.Sum(r => r.TotalPoints)
                                  });
