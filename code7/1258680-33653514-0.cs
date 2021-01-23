    var result = list.GroupBy(c => new { c.StoreName, c.Address1 }).
                      Select(c => new
                      {
                          ID = c.Min(i => i.ID),
                          c.Key.StoreName,
                          c.Key.Address1
                      }).ToList();
