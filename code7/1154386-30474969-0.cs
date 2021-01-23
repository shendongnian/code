    private readonly HttpClient httpClient = new HttpClient();
    private async Task<string> GetDataSetAsync(string request)
    {
		httpClient.BaseAddress = theBaseAddress;
		HttpResponseMessage response = await httpClient.GetAsync(request);
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadAsStringAsync();
    }
    
    private async Task PostDataSetAsync<T>(string request, T data)
    {
		client.BaseAddress = new Uri(theBaseAddress);
		HttpResponseMessage response = await client.PostAsJsonAsync<T>(request, data);
		response.EnsureSuccessStatusCode();	
    }
    
    internal async Task<MyDataSet> GetMyDataSetByIdAsync(int id)
    {
    	string request = String.Format("api/MyDataSet/GetById/{0}", id);
    	return JsonConvert.DeserializeObject<MyDataSet>(await GetDataSetAsync(request));
    }
    
    internal Task UpdateDataSetAsync(MyDataSet data)
    {
      	return PostDataSetAsync("api/MyDataSet/Update", data);
    }
