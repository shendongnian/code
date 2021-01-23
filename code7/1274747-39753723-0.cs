    Stream rs;    
    using (IAmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client())
    {
        GetObjectRequest getObjectRequest = new GetObjectRequest();
        getObjectRequest.BucketName = "mybucketname";
        getObjectRequest.Key = "mykey";
        using (var getObjectResponse = client.GetObject(getObjectRequest))
        {
                  getObjectResponse.ResponseStream.CopyTo(rs);
        }
    }    
