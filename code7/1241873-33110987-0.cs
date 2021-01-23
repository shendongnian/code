    var visits = _db.Visits.AsNoTracking().Select(c=> new{ City= c.City, Code = c.Code, Name = c.Name }).GroupBy(x => x.City)
                .Select(group => new
                {
                    City = group.Key.Code, 
                    CityName = group.Key.Name, 
                    Count = group.Count()
                }).OrderByDescending(x => x.Count);
