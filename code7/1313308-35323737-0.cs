    private HttpClient VrClient()
    {
        var httpHandler = new HttpClientHandler()
        {
            AllowAutoRedirect = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            UseCookies = true,
            CookieContainer = new CookieContainer()
        };
        var auth = Convert.ToBase64String(Encoding.ASCII.GetBytes(_vrCreds.Username + ":" + _vrCreds.Password));
        HttpClient client = HttpClientFactory.Create(httpHandler, new LoggingHandler());
        client.BaseAddress = new Uri(_vrCreds.Url);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
        if (learningOptOut)
        {
            client.DefaultRequestHeaders.Add("X-Watson-Learning-Opt-Out", learningOptOut.ToString());
        }
        return client;
    }
