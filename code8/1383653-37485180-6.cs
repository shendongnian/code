    // Assuming the names have been fixed to be idiomatic...
    var allCountries = response.Rates.Select(pair =>
        new Country {
            CountryName = pair.Value.CountryName,
            StandardRate = pair.Value.StandardRate,
            ShortCode = pair.Key
        })
        .ToList();
