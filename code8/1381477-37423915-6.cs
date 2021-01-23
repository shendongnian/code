    [WebMethod]
    public static string GetCitiesState()
    {
    	var result = new List<object>();
    	
    	//get stateList and cityList
    	//etc... your code here etc...
    	
    	foreach(State state in stateList)
    	{
    		var currentState = new {
    			id = state.Id,
    			state = state.State,
    			stateName = state.Name,
    			cities = new List<City>()
    		};
    		
    		foreach(City city in cityList)
    		{
    			if(city.StateId == state.Id)
    			{
    				currentState.cities.Add(city);
    			}
    		}
    		
    		//add it to the running state list
    		result.Add(currentState);
    	}
    	
    	return new JavaScriptSerializer().Serialize(result);
    }
