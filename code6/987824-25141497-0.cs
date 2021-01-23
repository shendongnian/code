    var places = _context.Places.Where(x => x.Published && x.Status != RecordStatus.Banned)
                                .GroupBy(x => x.City.Id)
                                .Select(x => new
                                 {
                                     CityId = x.Key,
                                     Count = x.Count()
                                 })
                                 .ToList(); // db query
    var cityIds = places.Select(y => y.CityId).ToList(); //in memory
    var cityModels = _context.Cities.Where(x => x.Published && cityIds.Contains(x.Id))
                                    .Select(x => new CityModel
                                    {
                                        Id = x.Id,
                                        Name = x.Name,
                                        Published = x.Published,
                                        StateId = x.State.Id,
                                        PlacesCount = 0
                                    })
                                    .ToList(); // db query
    cityModels.ForEach(x => x.PlacesCount = places.FirstOrDefault(y => y.CityId == x.Id).Count); //in memory
    var stateIds = cityModels.Select(x => x.StateId).Distinct().ToList(); //in memory
    var stateModels = _context.States.Where(x => x.Published && stateIds.Contains(x.Id))
                                     .Select(x => new StateModel
                                     {
                                         Id = x.Id,
                                         Name = x.Name
                                     }).ToList(); // db query
    stateModels.ForEach(x => x.Cities = cityModels.Where(y => y.StateId == x.Id)); //in memory
