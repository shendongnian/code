    private async Task<HttpResponseMessage> RunAsync()
    {
       HttpRequestMessage requestMessage = new HttpRequestMessage();
       requestMessage.RequestUri = "http://....";
       foreach (var header in this.Request.Headers)
          requestMessage.Headers.Add(header.Key, header.Value);
       HttpResponseMessage response = await requestMessage.SendAsync();
       string resultData = await response.Content.ReadAsStringAsync();
    }
