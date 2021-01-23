    public static List<Country> GetListOfCountires(List<String> cityNames)
    {
        return Countries
               .Where(country => country.Cities.Any(city => cityNames.Contains(city.Name))
               .ToList()
   
    }
