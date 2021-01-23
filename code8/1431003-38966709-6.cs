    var result = FinalList.Select(item => new 
                          { 
                              Date = new [] { item.Birthday.ToString("ddMM"), item.Anniversary.ToString("ddMM") }, 
                              Item = item 
                          })
                          .SelectMany(item => item.Date.Select(date => new { Date = date, Item = item.Item }))
                          .GroupBy(item => item.Date)
                          .Select(grouping => new { Date = grouping.Key, Events = grouping.ToList() }).ToList();
