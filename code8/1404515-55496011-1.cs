    public UserService(IHttpClientFactory clientFactory, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _clientFactory = clientFactory;
        }
    var request = new HttpRequestMessage(...
    var client = _clientFactory.CreateClient("HttpClientWithSSLUntrusted");
    HttpResponseMessage response = await client.SendAsync(request);
