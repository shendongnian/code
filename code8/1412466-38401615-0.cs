	public static class ValidatorNotExistHelper
	{
		public static string Country(int id)
		{
			return IdToString(ExistsHelper.Country,
                              GetTranslation(ConfigTranslationCode.CountryNotExist), id);
		}
	
		public static string State(int id)
		{
			return IdToString(ExistsHelper.State,
                              ConfigTranslationCode.StateNotExist, id);
		}
	
		public static string City(int id)
		{
			return IdToString(ExistsHelper.City,
                              ConfigTranslationCode.CityNotExist, id);
		}
	
		private static string IdToString(Predicate<int> exists, string defaultValue, int id)
		{
			return (!exists(id)) ? defaultValue : string.Empty;
		}
	}
