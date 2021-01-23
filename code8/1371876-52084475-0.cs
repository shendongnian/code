        public async Task MoveObjectAsync(string srcBucket, string srcKey, string destBucket, string destKey)
        {
            CopyObjectRequest request = new CopyObjectRequest
            {
                SourceBucket = srcBucket,
                SourceKey = srcKey,
                DestinationBucket = destBucket,
                DestinationKey = destKey                
            };
            CopyObjectResponse response = await _client.CopyObjectAsync(request);
            var request = new DeleteObjectRequest
            {
                BucketName = bucket,
                Key = key
            };
            var response = await _client.DeleteObjectAsync(request);
        }
