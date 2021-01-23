    private async Task<Uri> uploadImageFileToContainer(byte[] fileContent, string containerName, string blobName)
    { 
        ...
        await Task.Factory.FromAsync<IEnumerable<string>>(
            blockBlob.BeginPutBlockList, blockBlob.EndPutBlockList, blockList, blockBlob);
        blob.SetMetadata();
        return blob.Uri;
    }
