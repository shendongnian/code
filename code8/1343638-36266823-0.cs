    public List<Country> GetCountries(string locale)
    {
        var result = context.Countries.Select(c => new Country { Names = c.Names.Select(n => n.Locale == locale).ToList() }).ToList();
        return result;
    }
