    var query = filter.All
                      .Where(it => it.Target == '995fc819-954a-49af-b056-387e11a8875d')
                      .GroupBy(x => new { x.User, x.TimeStampDate })
                      .Select(x => new 
                             {
                                 TimeStampDate= x.Key.TimeStampDate,
                                 User = x.Key.User,
                                 Usage = x.Count()
                             }).ToList();
