    List<State> states = new List<State>();
    foreach(State state in stateList)
    {
        foreach(City city in cityList)
        {
            if(state.Id == city.StateId)
            {
                //state.Cities is a List<City> within the State model
                state.Cities.Add(city);
            }
        }
        //add it to the running states list
        states.Add(state);
    }
    
    //now return it
    var serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    return serializer.Serialize(states);
