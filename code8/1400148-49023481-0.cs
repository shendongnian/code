    private static HttpClient httpClient;
    public static HttpClient GetHttpClient()
    {
        if (httpClient == null)
        {
            httpClient = new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
        return httpClient;
    }
