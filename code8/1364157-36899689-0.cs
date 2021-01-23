    HttpBaseProtocolFilter filter = new HttpBaseProtocolFilter();
    filter.ServerCredential = new PasswordCredential( uri, username, password);
    HttpClient httpClient = new HttpClient(filter);
    
    HttpRequestMessage request = new HttpRequestMessage();
    request.Method = HttpMethod.Get;
    request.RequestUri = new Uri(uri, UriKind.Absolute);
    
    HttpResponseMessage response = await httpClient.SendRequestAsync(request);
