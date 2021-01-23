    // jsonData contains previously serialized List<User> and List<Request>
    void DeserializeUserAndRequest(string jsonData) 
    {
        var deserializedLists = new { 
            UserList = new List<User>(), 
            RequestList = new List<Request>() 
        };
        deserializedLists = JsonConvert.DeserializeAnonymousType(jsonData, deserializedLists);
        // Do your stuff here by accessing 
        //  deserializedLists.UserList and deserializedLists.RequestLists
    }
