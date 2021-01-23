        /// <summary>
        /// Code to fetch blobs from "temp" folder inside "blah" blob container.
        /// </summary>
        private static void GetFilesInSubfolder()
        {
            var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("blah");
            var directory = container.GetDirectoryReference("temp");
            var result = directory.ListBlobsSegmented(true, BlobListingDetails.None, 500, null, null, null);
            var blobs = result.Results;
        }
