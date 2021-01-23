    using (var context = new MyContext()) {
       var data =
          context
          .Continents
          .SelectMany(continent =>
             continent
             .Countries
             .SelectMany(country =>
                country
                .Cities
                .Select(city =>
                   new {
                      ContinentName = continent.Name,
                      CountryName = country.Name,
                      CityName = city.Name
                   }
                )
             )
          ).ToList();
       // do something with data
    }
