    private async Task Download(Uri uriToWork, CancellationToken cts) {
        using(HttpClient httpClient = new HttpClient()) {
            HttpRequestMessage requestAction = new HttpRequestMessage();
            requestAction.Method = new HttpMethod("GET");
            requestAction.RequestUri = uriToWork;
            HttpResponseMessage httpResponseContent = await httpClient.SendRequestAsync(requestAction, HttpCompletionOption.ResponseHeadersRead).AsTask(cts);
            string fileToWrite = Path.GetTempFileName();
            using(Stream streamToWrite = File.Open(fileToWrite, FileMode.Create)) {
                // Disposes streamToWrite to force any write operation to fail
                cts.Register(() => streamToWrite.Dispose());
                try {
                    await httpResponseContent.Content.WriteToStreamAsync(streamToWrite.AsOutputStream()).AsTask(cts, p);
                }
                catch(TaskCanceledException) {
                    return; // "gracefully" exit when the token is cancelled
                }
                await streamToWrite.FlushAsync();
            }
        }
    }
