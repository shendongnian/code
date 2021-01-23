    // Connect to storage account
    ...
    
    // Retrieve reference to a container. 
    myContainer= blobClient.GetContainerReference("mycontainer");
    // Create the container if it doesn't already exist.
    if (myContainer.CreateIfNotExists())
    {
        // Explicitly configure container for private access
        var permissions = myContainer.GetPermissions();
        permissions.PublicAccess = BlobContainerPublicAccessType.Off;
        myContainer.SetPermissions(permissions);   
    }
