    var applications = db.ElmahErrors.Where(s => s.Application.Replace("/", "")
                                                          .Replace(".", "") == queryString)
                       .GroupBy(s => s.Type)
                       .Select(grp => new
                                {
                                     ErrorCount = grp.Count(),
                                     ErrorObj = grp.FirstOrDefault()
                                });
