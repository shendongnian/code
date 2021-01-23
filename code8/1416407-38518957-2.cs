     if (result != null && (result.StatusCode == HttpStatusCode.OK) ) 
     {
       // here I made changes 
        RestSharp.Deserializers.JsonDeserializer deserial = new JsonDeserializer();
        List<RootObject> content = deserial.Deserialize<List<RootObject>>(result);
        foreach (var cont in content)
        {
            // Do your Stuff
        }
                 
     }
