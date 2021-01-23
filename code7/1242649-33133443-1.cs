    protected Task<T> Get<T>(string uri)
    {
      var client = GetNewClient();
      var request = new HttpRequestMessage(HttpMethod.Get, uri);
      return client.SendAsync(request)
          .ContinueWith(t => t.Result.Content.ReadAsAsync<T>())
          .Unwrap();
    }
