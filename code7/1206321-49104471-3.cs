    private static CloudBlobClient _blobClient = CloudStorageAccount.Parse("connectionstring").CreateCloudBlobClient();
    public async IAsyncEnumerable<CloudAppendBlob> GetBlobs()
    {
        var container = _blobClient.GetContainerReference("$logs");
        BlobContinuationToken continuationToken = null;
        //Use maxResultsPerQuery to limit the number of results per query as desired. `null` will have the query return the entire contents of the blob container
        int? maxResultsPerQuery = null;
    
        do
        {
            var response = await container.ListBlobsSegmentedAsync(string.Empty, true, BlobListingDetails.None, maxResultsPerQuery, continuationToken, null, null);
            continuationToken = response.ContinuationToken;
            foreach (var blob in response.Results.OfType<CloudAppendBlob>())
            {
                yield return blob;
            }
        } while (continuationToken != null);
    }
