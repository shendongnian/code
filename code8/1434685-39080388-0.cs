    var statusCounts = models.GroupBy(x => new { x.CurrentStatus, x.LastChanged })
                             .Select(g => new 
                             { 
                                 g.Key, 
                                 Count = models.Where(m => m.CurrentStatus == g.Key.CurrentStatus &&
                                                           m.LastChanged  <= g.Key.LastChanged).Count()
                             })
                             .OrderBy(item => item.Key.LastChanged);
