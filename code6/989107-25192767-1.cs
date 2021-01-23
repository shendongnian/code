    // Override default RestSharp JSON deserializer
    client = new RestClient();
    client.AddHandler("application/json", new DynamicJsonDeserializer());
     
    var response = client.Execute<dynamic>(new RestRequest("http://dummy/users/42"));
     
    // Data returned as dynamic object!
    dynamic user = response.Data.User;
