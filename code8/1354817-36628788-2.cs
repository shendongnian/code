     public static StartConfig GetConfig(string connectionString)
        {
            var config = new StartConfig();
            // Retrieve storage account from connection string.
            config.StorageAccount = CloudStorageAccount.Parse(connectionString);
            // Create the blob object.
            config.BlobClient = config.StorageAccount.CreateCloudBlobClient();
            config.ListContainerData = ListContainer(config);
            foreach (var item in config.ListContainerData.Item2)
            {
                config.Container = config.BlobClient.GetContainerReference(item);
                ShowSasTokenForContainer(config);
            }
            //Create the container if it does not exisit.
            config.Container.CreateIfNotExists();
            return config;
        }
