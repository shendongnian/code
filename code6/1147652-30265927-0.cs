    var countries = countriesDataSet.Countries;
    Country country = countries.FirstOrDefault(c => c.Id == id);
    if (country != null)
    {                    
        country.SomeProperty = newCountry.SomeProperty;
        country.SomethingElse = newCountry.SomethingElse;
        countriesDataSet.Save();                    
    }
