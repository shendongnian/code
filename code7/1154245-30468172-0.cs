    var sasConstraints = new SharedAccessBlobPolicy();
    sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5);
    sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(10);
    sasConstraints.Permissions = SharedAccessBlobPermissions.Read;
    
    var sasBlobToken = blob.GetSharedAccessSignature(sasConstraints);
    
    return blob.Uri + sasBlobToken;
