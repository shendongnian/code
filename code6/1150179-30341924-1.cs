    public object GetNamedParametersFrom(GenericObject genericObject)
    {
    	string[] namesFromLists = new string[genericObject.ListOfThings.Count];
        
        for (int i = 0; i < genericObject.ListOfThings.Count; i++)
        {
            namesFromLists[i] = genericObject.ListOfThings[i].Name;
        }
    
    	return namesFromLists; //As you are returning an `object`, you can return `resources` array directly from this method
    }
