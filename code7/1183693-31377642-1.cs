    IQueryable<ClassTracker> result = (from n in CS.trackers
                         group n by n.Id into g
                         let firstObj = g.OrderByDescending(t => t.DateTime).First()
                         select new ClassTracker
                         {
                             Id = firstObj .Id,
                             //Other properties here
                         }).AsQueryable<ClassTracker>();
