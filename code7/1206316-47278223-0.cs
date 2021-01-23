        private static CloudBlobClient _blobClient = CloudStorageAccount.Parse("connectionstring").CreateCloudBlobClient();
        public IEnumerable<CloudAppendBlob> GetBlobFiles()
        {
            var container = _blobClient.GetContainerReference("$logs");
            BlobContinuationToken continuationToken = null;
            do
            {
                var response = container.ListBlobsSegmented(string.Empty, true, BlobListingDetails.None, new int?(), continuationToken, null, null);
                continuationToken = response.ContinuationToken;
                foreach (var blob in response.Results.OfType<CloudAppendBlob>())
                {
                    yield return blob;
                }
            } while (continuationToken != null);
        }
