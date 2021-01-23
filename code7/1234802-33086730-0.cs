    public static bool IsNull(ClientObject clientObject)
    {
        //check object
        if (clientObject == null)
        {
            //client object is null, so yes, we're null (we can't even check the server object null property)
            return true;
        }
        else if (!clientObject.ServerObjectIsNull.HasValue)
        {
            //server object null property is itself null, so no, we're not null
            return false;
        }
        else
        {
            //server object null check has a value, so that determines if we're null
            return clientObject.ServerObjectIsNull.Value;
        }
    }
