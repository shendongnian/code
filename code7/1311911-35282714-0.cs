    public static class WebClientExtensios
    {
        public static async Task DownloadFileTaskAsync(
            this WebClient webClient, 
            Uri address, 
            string fileName, 
            IProgress<Tuple<long, int, long>> progress)
        {
            // Create the task to be returned
            var tcs = new TaskCompletionSource<object>(address);
    
            // Setup the callback event handler handlers
            AsyncCompletedEventHandler completedHandler = (cs, ce) =>
            {
                if (ce.UserState == tcs)
                {
                    if (ce.Error != null) tcs.TrySetException(ce.Error);
                    else if (ce.Cancelled) tcs.TrySetCanceled();
                    else tcs.TrySetResult(null);
                }
            };
    
            DownloadProgressChangedEventHandler progressChangedHandler = (ps, pe) =>
            {
                if (pe.UserState == tcs)
                {
                    progress.Report(
                        Tuple.Create(
                            pe.BytesReceived, 
                            pe.ProgressPercentage, 
                            pe.TotalBytesToReceive));
                }
            };
    
            try
            {
                webClient.DownloadFileCompleted += completedHandler;
                webClient.DownloadProgressChanged += progressChangedHandler;
    
                webClient.DownloadFileAsync(address, fileName, tcs);
                
                await tcs.Task;
            }
            finally
            {
                webClient.DownloadFileCompleted -= completedHandler;
                webClient.DownloadProgressChanged -= progressChangedHandler;
            }
        }
    }
