    public static IEnumerable<Game> GameByMatchingName(this IRepositoryAsync<Game> repository,  string searchCriteria, string countryId = null)
        {
             var ret = repository
              .Queryable()
                .Where(x=>x.Name.Contains(searchCriteria));
              if (!(countrId == null))
              {
                 ret = ret.Where(y=>y.CountryId == countryId )
              }
             return ret.AsEnumerable();;
         }
