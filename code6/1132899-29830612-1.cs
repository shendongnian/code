    try
    {
        objectToValidate = JObject.Parse(stringedObject);      
    }
    catch (Exception e)
    {
        if (e.GetType().IsSubclassOf(typeof(Exception)))
            throw;
    
        //Handle the case when e is the base Exception
        messages.Add("Unable to parse jsonObject.");
        return false;
    }
