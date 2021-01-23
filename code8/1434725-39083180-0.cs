    List<Continent> List = MyRepository.GetList<GetAllCountriesAndCities>("EXEC sp_GetAllCountriesAndCities")
        .GroupBy(x => x.ContinentName)
        .Select(g => new Continent 
        {
            ContinentName = g.Key,
            Countries = g.GroupBy(x => x.CountryName)
                         .Select(cg => new Country 
                         {
                             CountryName = g.Key,
                             Cities = cg.GroupBy(x => x.CityName)
                                        .Select(cityG => new City { CityName = cityG.Key })
                                        .ToList()
                         })
                         .ToList()
        })
        .ToList();
