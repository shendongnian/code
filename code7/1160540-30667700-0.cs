    City[] prepend = new City[] {new City { Id = 0, Name = "--Select City--"}};
    IEnumerable<City> cities = network.Continents
                          .SelectMany(continent => continent.Countries)
                          .Where(ctry => ctry.Id == "country")
                          .SelectMany(ctry =>  ctry.Cities,
                                      c => new City { Id = c.Id, Name = c.Name });
    var citySequence = prepend.Concat(cities);
    var cityList = citySequence.ToList();
