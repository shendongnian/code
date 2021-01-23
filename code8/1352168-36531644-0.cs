    public static HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(someURL)
            };
    
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            return httpClient;
        }
    public static async Task<string> Get(string path)
    {
        using (var client = CreateClient())
        {
            var getResponse = await client.GetAsync(path);
            return await getResponse.Content.ReadAsStringAsync();
        }
    } 
    public async Task<string> UpdateFriendsLocation()
        {
            var response = await WebServices.Get(someURL);
            return response;
        }
    //In the place you want
    var resp = JsonConvert.DeserializeObject<Handler>(response);
