    HttpClient client = new HttpClient();
    //make sure that this fails if it's hung for more than 30 seconds
    var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
    try
    {
        response = await client.SendAsync(request,
                                          HttpCompletionOption.ResponseHeadersRead, 
                                          cts.Token);
    }
    catch (TaskCanceledException)
    {
        response = new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
    }
