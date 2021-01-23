    [WebMethod]
    public static string GetCitiesState()
    {
    	var result = new List<object>();
    	
    	//get stateList and cityList
    	//etc... your code here etc...
    	boolean found=false;
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
                    found=true;
    				currentState.cities.Add(city);
    			}
    		}
    		
            if(found )
            { 
    		//add it to the running state list,only states that have cities.
            //on this situation it does not make sense because every states have  
            //cities but for extra info                                                                                              
    		result.Add(currentState);
            }
    	}
    	
    	return new JavaScriptSerializer().Serialize(result);
    }
