    async Task Download(Uri uriToWork, CancellationToken cts, IProgress<int> progress) {
        using(HttpClient httpClient = new HttpClient()) {
    
            var chunkSize = 1024;
            var buffer = new byte[chunkSize];
            int count = 0;
            string fileToWrite = Path.GetTempFileName();
    
            using(var inputStream = await httpClient.GetInputStreamAsync(uriToWork)) {
                using(var streamToRead = inputStream.AsStreamForRead()) {
                    using(Stream streamToWrite = File.OpenWrite(fileToWrite)) {
                        int size;
                        while((size = await streamToRead.ReadAsync(buffer, 0, chunkSize, cts).ConfigureAwait(false)) > 0) {
                            count += size;
                            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => progress.Report(count));
                            // progress.Report(count);
                            await streamToWrite.WriteAsync(buffer, 0, size, cts).ConfigureAwait(false);
                        }
                    }
                }
            }
        }
    }
