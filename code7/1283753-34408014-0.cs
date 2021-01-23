    async Task Main()
    {
    	using (var client = new HttpClient())
    	{
    		using (var request = new HttpRequestMessage())
    		{
    			request.RequestUri = new Uri("http://www.trola.si/bavarski");
    			request.Headers.Accept.Add(new  MediaTypeWithQualityHeaderValue("application/json"));
    			request.Method = HttpMethod.Get;
    			var result = await client.SendAsync(request);
    			string jsonStr = await result.Content.ReadAsStringAsync();
    			Result obj = JsonConvert.DeserializeObject<Result>(jsonStr);
    			obj.Dump();
    		}
    	}
    }
    
    // Define other methods and classes here
    public class Result
    {
        [JsonProperty(PropertyName = "stations")]
    	public Station[] Stations { get; set;}
    }
    
    public class Station
    {
    	[JsonProperty(PropertyName = "number")]
    	public string Number { get; set; }
    	[JsonProperty(PropertyName = "name")]
    	public string Name { get; set; }
    	[JsonProperty(PropertyName = "buses")]
    	public Bus[] Buses { get; set; }
    }
    
    
    public class Bus
    {
    	[JsonProperty(PropertyName = "direction")]
    	public string Direction { get; set; }
    	[JsonProperty(PropertyName = "number")]
    	public string Number { get; set; }
    	[JsonProperty(PropertyName = "arrivals")]
    	public int[] Arrivals { get; set; }
    }
