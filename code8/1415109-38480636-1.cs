    var events = db.Events.Select(item => new 
                                { 
                                    Month = DateTime.Parse(item.Request).Month,             
                                    Event = item
                                })
                          .GroupBy(x => x.Month)
    					  .Select(g => new { Month = g.Key, RequestCount = g.Count() })
    					  .ToList();
