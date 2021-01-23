    var grouped = Result
		.GroupBy(x => x.CountryName)
		.GroupBy(x => x.First().ContinentName);
    
    var final = grouped.Select(g1 => new Continent
    {
    	ContinentName = g1.Key,
    	Countries = g1.Select(g2 => new Country
    	{
    		CountryName = g2.Key,
    		Cities = g2.Select(x => new City { CityName = x.CityName }).ToList()
    	}).ToList()
    });
