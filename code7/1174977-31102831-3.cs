    public Task<string> TestDownloadTask()
    {
        using (HttpClient client = new HttpClient())
        {
            client.BaseAddress = new Uri(@"https://api.nasa.gov/planetary/apod");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
            // You don't need await here
            return client.GetStringAsync("?concept_tags=True&api_key=DEMO_KEY");
        }
    }
