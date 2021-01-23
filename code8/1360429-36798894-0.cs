    private HttpClient InitializeClient()
    {
        if (_client == null)
        {
            _client = GetHttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            SetBaseAddress(BaseAddress);
        }
        return _client;
    }
