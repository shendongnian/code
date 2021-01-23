    LiveConnectClient connectClient = new LiveConnectClient(this.Session);
    LiveOperationResult _opResult = await connectClient.GetAsync(FileID + "/content");
    dynamic _result = _opResult.Result;
    
    CancellationTokenSource cts = new CancellationTokenSource();
    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(_result.location as string, UriKind.Absolute));
    HttpResponseMessage response = await httpClient.SendRequestAsync(request, HttpCompletionOption.ResponseHeadersRead).AsTask(cts.Token);
    using (var _stream = (await OutputFile.OpenStreamForWriteAsync()).AsOutputStream())
    {
        await response.Content.WriteToStreamAsync(_stream).AsTask(cts.Token);
        await _stream.FlushAsync();
    }
