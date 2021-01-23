     CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
     var cts = new CancellationTokenSource((int)TimeSpan.FromSeconds(30 * (retryCount + 1)).TotalMilliseconds);
     using (var memoryStream = new System.IO.MemoryStream())
     {
        Task task = blockBlob.DownloadToStreamAsync(memoryStream, cts.Token);
        await task.ConfigureAwait(false);
        if (!task.IsCanceled && !task.IsFaulted)
        {
            return Encoding.UTF8.GetString(memoryStream.ToArray());                            
        }
        else if (task.IsCanceled)
        {
            retryCount++;
            Console.WriteLine("Task cancelled happened for blob: {0}. Increasing timeout to: {1} sec", blobName, retryCount * 30);
        }
    }
