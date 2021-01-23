    IEnumerable<Result> results = data.GroupBy(x => new { x.SiteId, x.SiteName })
                                      .Select(g => new Result
                                      {
                                          SiteId = g.Key.SiteId,
                                          SiteName = g.Key.SiteName,
                                          BusinessHours = g.Select(x => new BusinessHours
                                          {
                                             DayOfTheWeek = x.DayOfTheWeek,
                                             OpenTime = x.OpenTime,
                                             CloseTime = x.CloseTime
                                          })
                                      });
