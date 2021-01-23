	var response = await  client.GetAsync(url);
	var jsonMessage = await response.Content.ReadAsStringAsync();
	var serializer = new DataContractJsonSerializer(typeof(ApiResult));
	ApiResult result;
    // Disposing of the MemoryStream after the serialization to save 
    // some memory space
	using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonMessage)))
	{
		result = (ApiResult) serializer.ReadObject(ms);
	}
