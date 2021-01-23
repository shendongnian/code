    var visits = _db.Visits.AsNoTracking()
                 .Select(c=> new   // reduce the initial data set
                 { 
                     City= c.City, 
                     Code = c.Code, 
                     Name = c.Name 
                 })
                 .GroupBy(x => x.City)
                 .Select(group => new    // build results
                 {
                     City = group.Key.Code, 
                     CityName = group.Key.Name, 
                     Count = group.Count()
                 })
                 .OrderByDescending(x => x.Count);
