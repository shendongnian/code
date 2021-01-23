        static void FetchCloudBlobDirectories()
        {
            var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var containerName = "container-name";
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference(containerName);
            var containerUrl = container.Uri.AbsoluteUri;
            BlobContinuationToken token = null;
            List<string> blobDirectories = new List<string>();
            List<CloudBlobDirectory> cloudBlobDirectories = new List<CloudBlobDirectory>();
            do
            {
                var blobPrefix = "";//We want to fetch all blobs.
                var useFlatBlobListing = true;//This will ensure all blobs are listed.
                var blobsListingResult = container.ListBlobsSegmented(blobPrefix, useFlatBlobListing, BlobListingDetails.None, 500, token, null, null);
                token = blobsListingResult.ContinuationToken;
                var blobsList = blobsListingResult.Results;
                foreach (var item in blobsList)
                {
                    var blobName = (item as CloudBlob).Name;
                    var blobNameArray = blobName.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                    //If the blob is in a virtual folder/sub folder, it will have a "/" in its name.
                    //By splitting it, we are making sure that it is indeed the case.
                    if (blobNameArray.Length > 1)
                    {
                        StringBuilder sb = new StringBuilder();
                        //Since the blob name (somefile.png) will be the last element of this array and we're not interested in this,
                        //We only iterate through 2nd last element.
                        for (var i=0; i<blobNameArray.Length-1; i++)
                        {
                            sb.AppendFormat("{0}/", blobNameArray[i]);
                            var blobDirectory = sb.ToString();
                            if (blobDirectories.IndexOf(blobDirectory) == -1)//We check if we have already added this to our list or not
                            {
                                blobDirectories.Add(blobDirectory);
                                var cloudBlobDirectory = container.GetDirectoryReference(blobDirectory);
                                cloudBlobDirectories.Add(cloudBlobDirectory);
                                Console.WriteLine(cloudBlobDirectory.Uri);
                            }
                        }
                    }
                }
            }
            while (token != null);
        }
