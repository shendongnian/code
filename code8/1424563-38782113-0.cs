          private static void UploadToAWS(string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
          {
             string accessKey = ConfigurationManager.AppSettings["AMAZON_S3_ACCESSKEY"].ToString();
             string secretKey = ConfigurationManager.AppSettings["AMAZON_S3_SECRETKEY"].ToString();
             AmazonS3Config asConfig = new AmazonS3Config()
              {
        ServiceURL = "http://test.s3.amazonaws.com",
        RegionEndpoint = Amazon.RegionEndpoint.APSoutheast1 // this line fixed the issue
              };
             IAmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey,secretKey,asConfig);
           TransferUtility utility = new TransferUtility(client);
           TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();
          if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
           {
             request.BucketName = bucketName; //no subdirectory just bucket name
           }
          else
          {   // subdirectory and bucket name
           request.BucketName = bucketName + @"/" + subDirectoryInBucket;
         }
          request.Key = fileNameInS3; //file name up in S3
          request.FilePath = localFilePath; //local file name
          request.Headers.CacheControl = "public";
          request.Headers.Expires = DateTime.Now.AddYears(3);
          request.Headers.ContentEncoding = "gzip";
          utility.Upload(request); //commensing the transfer
       }
