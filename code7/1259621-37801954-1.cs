    public async Task<HttpResponseMessage> Get(int id)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            return await httpClient.GetAsync(url);
        }
    }
