    var s3Client = new AmazonS3Client(AccessKeyId, SecretKey, Amazon.RegionEndpoint.USEast1);
        using (s3Client)
        {
            MemoryStream ms = new MemoryStream();
            GetObjectRequest getObjectRequest = new GetObjectRequest();
            getObjectRequest.BucketName = BucketName;
            getObjectRequest.Key = awsFileKey;
            using (var getObjectResponse = s3Client.GetObject(getObjectRequest))
            {
                getObjectResponse.ResponseStream.CopyTo(ms);
            }
            var download = new FileContentResult(ms.ToArray(), "image/png"); //"application/pdf"
            download.FileDownloadName = ToFilePath;
            return download;
        }
