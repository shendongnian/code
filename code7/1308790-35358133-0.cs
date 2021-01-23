    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        return Task.FromResult(Execute(_resourceUri));
    }
    public HttpResponseMessage Execute(String resourceUri)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(resourceUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return client.GetAsync("api/songs").Result;
            }
        }
