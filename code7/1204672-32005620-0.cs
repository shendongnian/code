    var applications = db.ElmahErrors.GroupBy(x => x.ApplicationName)
                                     .Select(x => new 
                                           {
                                              ApplicationName = x.Key,
                                              Errors = x.OrderByDescending(s => s.TimeUtc);
                                           });
