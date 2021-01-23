        private static void DownloadLargeFile()
        {
            var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("container-name");
            var file = "my-very-large-file-name";
            var blob = container.GetBlockBlobReference(file);
            //First fetch the size of the blob. We use this to create an empty file with size = blob's size
            blob.FetchAttributes();
            var blobSize = blob.Properties.Length;
            long blockSize = (1 * 1024 * 1024);//1 MB chunk;
            blockSize = Math.Min(blobSize, blockSize);
            //Create an empty file of blob size
            using (FileStream fs = new FileStream(file, FileMode.Create))//Create empty file.
            {
                fs.SetLength(blobSize);//Set its size
            }
            var blobRequestOptions = new BlobRequestOptions
            {
                RetryPolicy = new ExponentialRetry(TimeSpan.FromSeconds(5), 3),
                MaximumExecutionTime = TimeSpan.FromMinutes(60),
                ServerTimeout = TimeSpan.FromMinutes(60)
            };
            long currentPointer = 0;
            long bytesRemaining = blobSize;
            do
            {
                var bytesToFetch = Math.Min(blockSize, bytesRemaining);
                using (MemoryStream ms = new MemoryStream())
                {
                    //Download range (by default 1 MB)
                    blob.DownloadRangeToStream(ms, currentPointer, bytesToFetch, null, blobRequestOptions);
                    ms.Position = 0;
                    var contents = ms.ToArray();
                    using (var fs = new FileStream(file, FileMode.Open))//Open that file
                    {
                        fs.Position = currentPointer;//Move the cursor to the end of file.
                        fs.Write(contents, 0, contents.Length);//Write the contents to the end of file.
                    }
                    currentPointer += contents.Length;//Update pointer
                    bytesRemaining -= contents.Length;//Update bytes to fetch
                }
            }
            while (bytesRemaining > 0);
        }
