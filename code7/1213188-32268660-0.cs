    var ErrorsByapplications = from s in db.ElmahErrors
                       where s.TimeUtc >= startDate && s.TimeUtc < endDate
                       group s by new {s.ApplicationName, s.Type } into g
                       select new 
                         {
                            ApplicationName = g.Key,
                            Type = g.Key,
                            TotalErrors = g.Count()
                           ...and so on
                         };
