	public T MyRequest<T>(string resource) where T : new()
	{
		var client = new RestClient("http://Service-url.com");
		var request = new RestRequest(resource, Method.GET);
		var response = client.Execute(request);
		JsonDeserializer jsonDeserializer = new JsonDeserializer();
		return jsonDeserializer.Deserialize<T>(response);
	}
	
