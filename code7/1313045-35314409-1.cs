    var list = new List<City>();
    
                foreach (var iCity in iQueryable.ToList())// return iqueryable to list
                {
    
                    var city = new City
                    {
                        Id = iCity.Id,
                        Name = iCity.Name
                    };
    
                    list.Add(city);
                }
    
                return list;
