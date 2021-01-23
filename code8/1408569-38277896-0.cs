    public static IEnumerable<Game> GameByMatchingName(this IRepositoryAsync<Game> repository,  string searchCriteria, string countryId = null)
        {
            return repository
                .Queryable()
                .Where(x => (countryId == null) || (x.CountryId == countryId && x.Name.Contains(searchCriteria)).AsEnumerable();
        }
