    try
    {
         CancellationTokenSource cts = new CancellationTokenSource(2000);
         HttpClient client = new HttpClient();
         client.DefaultRequestHeaders.Accept.Add(new Windows.Web.Http.Headers.HttpMediaTypeWithQualityHeaderValue(""));
         HttpRequestMessage msg = new HttpRequestMessage(new HttpMethod("POST"), new Uri("Url"));
         HttpResponseMessage response = await client.SendRequestAsync(msg).AsTask(cts.Token);
    }
    catch(TaskCanceledException ex)
    {
    }
