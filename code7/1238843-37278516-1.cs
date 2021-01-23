         AmazonS3Config S3Config = new AmazonS3Config()
            {
                ServiceURL = "s3.amazonaws.com",
                CommunicationProtocol = Amazon.S3.Model.Protocol.HTTP,
            };
           
         const string AWS_ACCESS_KEY = "xxxxxxxxxxxxxxxx";
         const string AWS_SECRET_KEY = "yyyyyyyyyyyyyyyy";            
         AmazonS3Client client = new AmazonS3Client(AWS_ACCESS_KEY, AWS_SECRET_KEY, S3Config);
            DeleteObjectsRequest request2 = new DeleteObjectsRequest();
            ListObjectsRequest request = new ListObjectsRequest
            {
                BucketName = "yourbucketname",
                Prefix = "yourprefix"
                
            };
            
            ListObjectsResponse response = await client.ListObjectsAsync(request);
                    // Process response.
                    foreach (S3Object entry in response.S3Objects)
                    {
                        
                        request2.AddKey(entry.Key);
                    }
            request2.BucketName = "yourbucketname";
            DeleteObjectsResponse response2 = await client.DeleteObjectsAsync(request2);
