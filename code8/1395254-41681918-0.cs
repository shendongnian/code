    // Add Data Protection so that cookies don't get invalidated when swapping slots.
    string storageUrl = Configuration.GetValue<string>("DataProtection:StorageUrl");
    string sasToken = Configuration.GetValue<string>("DataProtection:SasToken");
    string containerName = Configuration.GetValue<string>("DataProtection:ContainerName");
    string applicationName = Configuration.GetValue<string>("DataProtection:ApplicationName");
    string blobName = Configuration.GetValue<string>("DataProtection:BlobName");
 
    // If we have values for all these things set up the data protection store in Azure.
    if (storageUrl != null && sasToken != null && containerName != null && applicationName != null && blobName != null)
    {
        // Create the new Storage URI
        Uri storageUri = new Uri($"{storageUrl}{sasToken}");
 
        //Create the blob client object.
        CloudBlobClient blobClient = new CloudBlobClient(storageUri);
 
        //Get a reference to a container to use for the sample code, and create it if it does not exist.
        CloudBlobContainer container = blobClient.GetContainerReference(containerName);
        container.CreateIfNotExists();
 
        services.AddDataProtection()
            .SetApplicationName(applicationName)
            .PersistKeysToAzureBlobStorage(container, blobName);
    }
