    // Extension method to post a JSON
    public static async Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string addr, object obj)
    {
      	var response = await client.PostAsync(addr, new StringContent(
             	Newtonsoft.Json.JsonConvert.SerializeObject(obj),
           		Encoding.UTF8, "application/json"));
            			
        return response;
    }
