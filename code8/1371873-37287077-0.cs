    AmazonS3Config cfg = new AmazonS3Config();
    cfg.RegionEndpoint = Amazon.RegionEndpoint.EUCentral1;//bucket location
    string bucketName = "source bucket";
    AmazonS3Client s3Client = new AmazonS3Client("your accessKey", "your secretKey", cfg);
    
    S3DirectoryInfo source = new S3DirectoryInfo(s3Client, bucketName, "sourceFolder");
     string bucketName2 = "destination butcket";               
        S3DirectoryInfo destination = new S3DirectoryInfo(s3Client, bucketName2);
      source.CopyTo(destination); 
    // or 
    source.MoveTo(destination);
