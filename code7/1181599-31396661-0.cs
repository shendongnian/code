    var request = (HttpWebRequest)WebRequest.Create(uri);
    // ...
    try 
    {
        using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
        {
            await request.GetResponseAsyncCancelable(cts.Token);
        }
    }
    catch (OperationCanceledException)
    {
        // handle cancellation, if desired
    }
    // ...
    public static class HttpWebRequestExt
    {
        public static async Task<HttpWebResponse> GetResponseAsyncCancelable(
            this HttpWebRequest @this, 
            CancellationToken token)
        {
            using (token.Register(() => request.Abort(), useSynchronizationContext: false))
            {
                try
                {
                    // BTW: any reason why not use request.GetResponseAsync,
                    // rather than FromAsync? It's there in WP 8.1:
                    // var response = await request.GetResponseAsync();
                    var response = (HttpWebResponse)await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request);
                    token.ThrowIfCancellationRequested();
                    return response;
                }
                catch (WebException ex)
                {
                    // WebException caused by cancellation?
                    if (!token.IsCancellationRequested)
                        throw; // no, just re-throw
                    // yes, wrap it with OperationCanceledException
                    throw new OperationCanceledException(ex.Message, ex, token);
                }
            }
        }
    }
