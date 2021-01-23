    // using Windows.Web.Http;
    // using Windows.Web.Http.Filters;
    var parameters = GetParameters();
    var formattedData = new HttpFormUrlEncodedContent(parameters);
    using (var clientHandler = new HttpBaseProtocolFilter())
    {
        clientHandler.clientHandler = GetCredentials();
        
        using (var httpClient = new HttpClient(clientHandler))
        {
            var response = await httpClient.PostAsync(postUrl, formattedData);
        }
    }
