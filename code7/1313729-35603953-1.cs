    [WebInvoke(Method = "GET", UriTemplate = "UploadBlob", ResponseFormat = WebMessageFormat.Json)]
    public void UploadBlob(Stream fileStream)
    {
        // Connect to the storage account's blob endpoint 
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("BlobConnectionString"));
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
    
        // Create the blob storage container 
        CloudBlobContainer container = blobClient.GetContainerReference("mycontainer");
        container.CreateIfNotExists();
    
        // Create the blob in the container 
        CloudBlockBlob blob = container.GetBlockBlobReference("nature");
        blob.UploadFromStream(fileStream);
    
    }
