    public class LocaleCountry
    {
        public int CountryId {get;set;}
        public string Name {get;set;}
        public string Locale {get;set;}
    }
    public List<LocaleCountry> GetCountries(string locale)
    {
        var result = context.Countries
            .Select(c => new LocaleCountry
            {
                CountryId = c.Id,
                Name = c.Names
                   .Where(n => n.Locale == locale)
                   .Select(n => n.Name)),
                Locale = locale
            })
            .ToList();
        return result;
    }
