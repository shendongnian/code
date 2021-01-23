    class Helper
    {
        public int GetCountryIdByCity(int cityId)
        {
            City city = databaseContext.States.Where(cty => cty.CityId == cityId).First();
            State state = databaseContext.States.Where(st => st.StateId == city.StateId).First();
            return databaseContext.Countries.Where(ctry => ctry.CountryId == state.CountryId).First().CountryId;
        }
    }
