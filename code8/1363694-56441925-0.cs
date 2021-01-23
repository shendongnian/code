    internal async Task CreateBucketAsync(string bucket, CancellationToken token)
    {
        if (string.IsNullOrEmpty(bucket)) return;
    
        using (var amazonClient = GetAmazonClient)
        {
            if (AmazonS3Util.DoesS3BucketExist(amazonClient, bucket)) return;
            await amazonClient.PutBucketAsync(new PutBucketRequest { BucketName = bucket, UseClientRegion = true }, token);
            await SetMultiPartLifetime(amazonClient, bucket, token);
        }
    }
