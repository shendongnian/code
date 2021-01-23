    protected Task<T> Get<T>(string uri)
    {
      var tcs = new TaskCompletionSource<T>();
      var client = GetNewClient();
      var request = new HttpRequestMessage(HttpMethod.Get, uri);
      client.SendAsync(request)
        .Completed(t =>
        {
          tcs.TrySetResult(t.Result.Content.ReadAsAsync<T>().Result);
        })
        .Errored(t =>
        {
          tcs.TrySetException(t.Exception);
        });
      return tcs.Task;
    }
