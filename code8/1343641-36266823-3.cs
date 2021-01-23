    public List<Country> GetCountries(string locale)
    {
        var result = context.Countries.Select(c => new Country { Names = c.Names.Select(n => n.Locale == locale).ToList() }).ToList();
        return result;
    }
    public List<Country> GetCountries(string locale)
    {
        var result = context.Countries.Where(c => c.Names.Any(n => n.Locale == locale)).ToList();
        result.ForEach(c => c.Names = c.Names.Where(n => n.Locale == locale).ToList());
        return result;
    }
