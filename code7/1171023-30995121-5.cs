    private async Task<Stream> ExecuteRequestAsync(Uri uri, HttpMethod method)
    {
        Stream stream = null;
        using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, uri))
        {
           try
           {
              stopwatch.Start();
              HttpResponseMessage responseMessage = await httpClient
                                                          .SendAsync(httpRequestMessage)
                                                          .ConfigureAwait(false);
              stream = await responseMessage.Content.ReadAsStreamAsync()
                                                    .ConfigureAwait(false);
           }
           catch(Exception GettingStreamException)
           {
              // Error checking code
           }  
        }
        return stream;
    }
