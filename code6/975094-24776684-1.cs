    public string GetBlobPathWithSas(string myBlobName)
    {
        // Get container reference
        ...
        // Get the blob, in my case an image
        CloudBlockBlob blob = myContainer.GetBlockBlobReference(myBlobName);        
        // Generate a Shared Access Signature that expires after 1 minute, with Read and List access 
        // (A shorter expiry might be feasible for small files, while larger files might need a 
        // longer access period)
        string sas = myContainer.GetSharedAccessSignature(new SharedAccessBlobPolicy()
        {
            SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(1),
            Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.List
        });
        return (blob.Uri.ToString() + sas).ToString();
    }
