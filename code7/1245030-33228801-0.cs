            var xp = (from p in db.ManDaysReals
                      group p by p.Date into g
                      select new
                      {
                          Date = g.Key,
                          ManDays = g.Sum(p => p.ManDays)
                      }).ToList();
            var xa = (from p in db.EstateAttendances
                      group p by p.Date into g
                      select new
                      {
                          Date = g.Key,
                          ManDays = g.Sum(p => p.ManDays)
                      }).ToList();
            var xt =  from p in xp
                      join a in xa on p.Date equals a.Date
                      select new CompareMandaysViewModel
                      {
                          Date = p.Date,
                          HKMandays = p.ManDays,
                          HKAttendance = a.ManDays
                      };
