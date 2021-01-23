    var ErrorsByapplications = from s in db.ElmahErrors
                               where s.TimeUtc >= startDate && s.TimeUtc < endDate
                               group s by new {s.Application, s.Type } into g
                               select new 
                               {
                                  ApplicationName = g.Key,
                                  Error = g.ToList()
                               };
