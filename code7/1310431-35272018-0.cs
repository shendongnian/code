    string AccessKeyId = "REMOVED";
    string SecretAccessKey = "nOt/a+ReAl/kEY";
    BasicAWSCredentials awsCreds = new BasicAWSCredentials(AccessKeyId, SecretAccessKey);
    
    AmazonS3Config S3Config = new AmazonS3Config
    {
        ServiceURL = "https://folder.s3.amazonaws.com/",
        RegionEndpoint = RegionEndpoint.USEast1
    };
    
    AmazonS3Client s3Client = new AmazonS3Client(awsCreds, S3Config);
    
    ListObjectsRequest request = new ListObjectsRequest();
    request.BucketName = "folder";
    request.Prefix = "folder/another_folder/";
    
    ListObjectsResponse response = s3Client.ListObjects(request);
    foreach (var item in response.S3Objects)
    {
        sr.WriteLine(item.Key.ToString());
    }
