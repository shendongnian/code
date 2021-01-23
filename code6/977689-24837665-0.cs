    public List<City> GetAllCity(bool SortOnCity, bool SortOnCountry)
    {
        //main code omitted for brevity
    
        if (SortOnCity)
            return obj.OrderBy(x => x.ctyName).ToList();
        else if (SortOnCountry)
            return obj.OrderBy(x => x.Country.cmName).ToList();
        else if (SortOnCity && SortOnCountry)
            return obj.OrderBy(x => new {x.ctyName, x.Country.cmName}).ToList();
    }
