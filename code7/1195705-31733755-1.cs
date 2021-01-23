    public async Task<string> Upload(MemoryStream stream, string fileName, string folder, bool overwrite = false)
    {
        var blobClient = _storageAccount.CreateCloudBlobClient();
        var container = blobClient.GetContainerReference(folder);
        await container.CreateIfNotExistsAsync();
        var blockBlob = container.GetBlockBlobReference(fileName);
        blockBlob.UploadFromStream(stream);
        return blockBlob.StorageUri.PrimaryUri.AbsolutePath;
    }
