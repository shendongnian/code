    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    var containerExists = container.Exists(new BlobRequestOptions() {
        ServerTimeout = TimeSpan.FromMinutes(5) 
    });
    if (!containerExists)
    // ...
