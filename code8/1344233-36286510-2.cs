    public IRestResponse<T> Execute<T>(RestRequest request) where T : new()
    {
       var response = client.Execute(request); // Client is of type RestClient
       return JsonConvert.DeserializeObject<T>(response.Content);
    }
