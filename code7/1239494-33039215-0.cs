        string key = "";
        string accountName = "mystorageaccount";
        string connectionString = "DefaultEndpointsProtocol=https;AccountName="
                                + accountName + ";AccountKey=" + key;
        var account = CloudStorageAccount.Parse(connectionString);
        var blobClient = account.CreateCloudBlobClient();
        //below line not necessary, just for demo how to get a container.
        var blobContainer = blobClient.GetContainerReference("mycontainer");
        List<ICloudBlob> allblobs = new List<ICloudBlob>;
        foreach(CloudBlobContainer container in blobClient.ListContainers())
        {
            allblobs.AddRange((from ICloudBlob blob in
                            container.ListBlobs(useFlatBlobListing: true)
                            select blob));
        }
