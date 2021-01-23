    var restClient = new RestClient(baseURL);
    client.AddHandler("application/xml", new XmlResultDeserializer());
    var request = new RestRequest(uri);
    request.Method = Method.POST;
    var result = restClient.Execute<Result<User>>(request);
    if (response.Data.Data != null)
    {
        var user = response.Data.Data;
        // Do something with the user...
    }
    else if (response.Data.Error != null)
    {
        var error = response.Data.Error;
        // Handle error...
    }
