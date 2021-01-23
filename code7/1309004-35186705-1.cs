    customArray.AddRange( db.Countries
        .Where(x => x.name.Contains(searchText))
        .OrderByDescending(o => o.id)
        .Select(c => new CustomClass { name = c.name, countCities = c.Cities.Count() })
    );
