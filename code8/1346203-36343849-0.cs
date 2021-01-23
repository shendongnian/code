    public static Expression<Func<CountryData, CountryDataDto>> ConverterExpression = cd => new CountryDataDto
            {
                Population = cd.Population
            };
    public static async Task<List<CountryDto>> ToDtosAsync(this IQueryable<Country> source, string locale)
    {
        if(source == null)
        {
            return null;
        }
    
        var result = await source
            .AsExpandable
            .Select(src => new CountryDto
            {    
               Name = src.NamesLocalized.FirstOrDefault(n => n.Locale == locale).Name
               Data = ConverterExpression.Invoke(src.Data)
            })
            .ToListAsync();
    
        return result; 
    }
