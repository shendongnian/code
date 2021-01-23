        static void DownloadBlobSnapshot()
        {
            var cred = new StorageCredentials(accountName, accountKey);
            var account = new CloudStorageAccount(cred, true);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference("snapshot-download-test");
            IEnumerable listOfBlobs = container.ListBlobs(null, true, BlobListingDetails.Snapshots);
            var downloadPath = @"D:\temp\";
            foreach (IListBlobItem blobItem in listOfBlobs)
            {
                var theBlob = blobItem as CloudBlockBlob;
                if (theBlob != null)
                {
                    if (theBlob.IsSnapshot)
                    {
                        theBlob.DownloadToFile(downloadPath + theBlob.Name.Replace("/", "\\"), FileMode.Create);
                    }
                }
            }
        }
