           //connection string
            string storageAccount_connectionString = "**NOTE: CONNECTION STRING**";
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageAccount_connectionString);
            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference("**NOTE:NAME OF CONTAINER**");
            //The specified container does not exist
            try
            {
                //root directory
                CloudBlobDirectory dira = container.GetDirectoryReference(string.Empty);
                //true for all sub directories else false 
                var rootDirFolders = dira.ListBlobsSegmentedAsync(true, BlobListingDetails.Metadata, null, null, null, null).Result;
                foreach (var blob in rootDirFolders.Results)
                {
                    if (blob is CloudBlockBlob blockBlob)
                    {
                        var time = blockBlob.Properties.LastModified;
                        Console.WriteLine("Data", time);
                    }
                }
            }
            catch (Exception e)
            {
                //  Block of code to handle errors
                Console.WriteLine("Error in the root directory", e);
            }
