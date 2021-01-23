    var client = new RestClient { BaseUrl = new Uri("http://myhost.com:22333") };
    var request = new RestRequest { Resource = "/site/api", RequestFormat = DataFormat.Json };
    var param = new Parameter
    {
        Type = ParameterType.GetOrPost,
        Name = "json_input",
        Value = new
        {
            fieldtype = "name",
            value = "joe"
        }
    };
    request.AddParameter(param);
            
    client.Authenticator = new NtlmAuthenticator();
    var response = client.Post(request);            
    if (response.StatusCode == System.Net.HttpStatusCode.Created)
    {
        var deserializer = new JsonDeserializer();
        var jsonDto = deserializer.Deserialize<ResultObj>(response);
    }
