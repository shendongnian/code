    public async Task<Stream> GetWriteStreamAsync(string storagePath, string contentType)
    {
        var blockBlob = blobContainer.GetBlockBlobReference(storagePath);
        blockBlob.Properties.ContentType = contentType;
        CloudBlobStream bb = await blockBlob.OpenWriteAsync();
        return bb;
    }
