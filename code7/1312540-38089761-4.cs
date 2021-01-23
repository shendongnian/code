     AmazonS3Config cfg = new AmazonS3Config();  
        cfg.RegionEndpoint = Amazon.RegionEndpoint.SAEast1;//your region Endpoint
        string butcketName = "yourBucketName";
        AmazonS3Client s3Client = new AmazonS3Client("your access key",
         "your secret key", cfg);
         PutObjectRequest request = new PutObjectRequest()
                        {
                            BucketName = _bucket,
                            InputStream = stream,
                            Key = fullName
                        };
        
                        s3Client.PutObject(request);
    
    or
    
        AmazonS3Config asConfig = new AmazonS3Config()
        {
            ServiceURL = "http://irisdb.s3-ap-southeast2.amazonaws.com/",
            RegionEndpoint = Amazon.RegionEndpoint.APSoutheast2
        };
