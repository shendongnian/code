    var cityList = network.Continents
                      .SelectMany(continent => continent.Countries)
                      .Where(ctry => ctry.Id == "country")
                      .SelectMany(ctry =>  ctry.Cities,
                                  c => new City { Id = c.Id, Name = c.Name })
                      .ToList();
    // yup, this is what I would do...
    cityList.Insert(0, new City{ Id = 0, Name = "--Select City--"});
