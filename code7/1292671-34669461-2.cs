    results = httpClient.GetStringAsync(url).Result;
    var restResponse = new RestSharp.RestResponse();
    restResponse.Content = results;
    var deserializer = new JsonDeserializer();
    var page = _deserializer.Deserialize<Rootobject>(restResponse);
