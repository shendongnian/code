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
                        while((size = await streamToRead.ReadAsync(buffer, 0, chunkSize, cts)) > 0) {
                            count += size;
                            progress.Report(count);
                            await streamToWrite.WriteAsync(buffer, 0, size, cts);
                        }
                    }
                }
            }
        }
    }
