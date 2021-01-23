    BlobServiceClient blobServiceClient = new BlobServiceClient("YourStorageConnectionString");
    BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("YourContainerName");
    var blobs = containerClient.GetBlobs();
    foreach (var item in blobs){
        Console.WriteLine(item.Name);
    }
