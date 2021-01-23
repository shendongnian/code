    [WebMethod]
    public static string GetCitiesState()
    {
    	Dictionary<string, object> result = new Dictionary<string, object>();
    	
    	List<State> states = StateList();
    	List<City> cities = CityList();
    	
    	result.Add("states", states);
    	result.Add("cities", cities);
    	
    	return new JavaScriptSerializer().Serialize(result);
    }
