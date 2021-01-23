    // Retrieve storage account from connection string.
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(_blobcnxn);
    // Create the blob client.
    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    // Retrieve a reference to a container.
    CloudBlobContainer container = blobClient.GetContainerReference(containerName);
    
    using (MemoryStream memoryStream = new MemoryStream())
    {
        newPic.Save(memoryStream, ImageFormat.Jpeg);
        memoryStream.Seek(0, SeekOrigin.Begin); // otherwise you'll get zero byte files
        CloudBlockBlob blockBlob = jpegContainer.GetBlockBlobReference(filename);
        blockBlob.UploadFromStream(memoryStream);
    }
