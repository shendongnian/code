        public bool IsBucketExists(AmazonS3Request argAmazonS3Request)
        {
            Boolean l_IsBucketExists = false;
            if (AmazonS3ClientObject == null)
                AmazonS3ClientObject = GetAmazonS3Client(argAmazonS3Request);
            ListBucketsResponse response = AmazonS3ClientObject.ListBuckets();
            IEnumerable<S3Bucket> l_IEnumerableS3Bucket = response.Buckets.Where(bucket => bucket.BucketName == argAmazonS3Request.BucketName);
            if (l_IEnumerableS3Bucket.Count() > 0)
                l_IsBucketExists = true;
            return l_IsBucketExists;
        }
        internal AmazonS3Client GetAmazonS3Client(AmazonS3Request argAmazonS3Request)
        {
            if (AmazonS3ClientObject == null)
            {
                AmazonS3ClientObject = (AmazonS3Client)Amazon.AWSClientFactory.CreateAmazonS3Client(argAmazonS3Request.AwsAccessKey, argAmazonS3Request.AwsSecretAccessKey, Amazon.RegionEndpoint.USEast1);
            }
            return AmazonS3ClientObject;
        }
        public void CreateBucket(AmazonS3Request argAmazonS3Request)
        {
            AmazonS3ClientObject = GetAmazonS3Client(argAmazonS3Request);
            //ListBucketsResponse response = AmazonS3ClientObject.ListBuckets();
            //foreach (S3Bucket s3Bucket in response.Buckets)
            //{
            //    if (s3Bucket.BucketName == argAmazonS3Request.BucketName)
            //    {
            //        ListObjectsRequest request = new ListObjectsRequest();
            //        request.BucketName = argAmazonS3Request.BucketName;
            //        ListObjectsResponse listObjectsResponse = AmazonS3ClientObject.ListObjects(request);
            //        foreach (S3Object o in listObjectsResponse.S3Objects)
            //        {
            //            Console.WriteLine("{0}\t{1}\t{2}", o.Key, o.Size, o.LastModified);
            //            DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest();
            //            deleteObjectRequest.BucketName = argAmazonS3Request.BucketName;
            //            deleteObjectRequest.Key = o.Key;
            //            AmazonS3ClientObject.DeleteObject(deleteObjectRequest);
            //        }
            //    }
            //}
            if (IsBucketExists(argAmazonS3Request) == false)
            {
                //DeleteBucketRequest deleteBucketRequest = new DeleteBucketRequest();
                //deleteBucketRequest.BucketName = argAmazonS3Request.BucketName;
                //AmazonS3ClientObject.DeleteBucket(deleteBucketRequest);
                // Create bucket
                PutBucketRequest putBucketRequest = new PutBucketRequest();
                putBucketRequest.BucketName = argAmazonS3Request.BucketName;
                putBucketRequest.CannedACL = S3CannedACL.PublicRead;
                AmazonS3ClientObject.PutBucket(putBucketRequest);
            }
        }
        public void CreateFolder(AmazonS3Request argAmazonS3Request)
        {
            Boolean IsFolderExists = false;
            AmazonS3ClientObject = GetAmazonS3Client(argAmazonS3Request);
            if (IsBucketExists(argAmazonS3Request) == false)
            {
                CreateBucket(argAmazonS3Request);
            }
            ListBucketsResponse response = AmazonS3ClientObject.ListBuckets();
            foreach (S3Bucket s3Bucket in response.Buckets)
            {
                if (s3Bucket.BucketName == argAmazonS3Request.BucketName)
                {
                    ListObjectsRequest request = new ListObjectsRequest();
                    request.BucketName = argAmazonS3Request.BucketName;
                    ListObjectsResponse listObjectsResponse = AmazonS3ClientObject.ListObjects(request);
                    foreach (S3Object l_S3Object in listObjectsResponse.S3Objects)
                    {
                        if (l_S3Object.Key == argAmazonS3Request.FolderName + @"/")
                            IsFolderExists = true;
                    }
                }
            }
            if (IsFolderExists == false)
            {
                var key = string.Format(@"{0}/", argAmazonS3Request.FolderName);
                PutObjectRequest putObjectRequestFolder = new PutObjectRequest();
                putObjectRequestFolder.BucketName = argAmazonS3Request.BucketName;
                putObjectRequestFolder.Key = key;
                AmazonS3ClientObject.PutObject(putObjectRequestFolder);
            }
        }
        public void PutFileInFolder(AmazonS3Request argAmazonS3Request)
        {
            AmazonS3ClientObject = GetAmazonS3Client(argAmazonS3Request);
            MemoryStream memStream = new MemoryStream();
            using (FileStream fileStream = File.OpenRead(argAmazonS3Request.FilePath))
            {
                memStream.SetLength(fileStream.Length);
                fileStream.Read(memStream.GetBuffer(), 0, (int)fileStream.Length);
            }
            PutObjectRequest putObjectRequestFile = new PutObjectRequest();
            putObjectRequestFile.FilePath = argAmazonS3Request.FilePath;
            // putObjectRequestFile.Key = AwsSecretAccessKey;
            m_ObjectKey = Convert.ToString(Guid.NewGuid()).Replace("-", string.Empty); // Object key will be used for pre singed public url.
            putObjectRequestFile.Key = m_ObjectKey;
            putObjectRequestFile.BucketName = argAmazonS3Request.BucketName + "/" + argAmazonS3Request.FolderName;
            putObjectRequestFile.CannedACL = S3CannedACL.PublicRead;
            putObjectRequestFile.StorageClass = S3StorageClass.Standard;
            AmazonS3ClientObject.PutObject(putObjectRequestFile);
        }
        public void GetPreSignedPublicUrlOfAmazonS3ile(AmazonS3Request argAmazonS3Request)
        {
            try
            {
                string l_Url = string.Empty;
                // create bucket
                CreateBucket(argAmazonS3Request);
                // create folder in bucket
                CreateFolder(argAmazonS3Request);
                // put file in the folder
                PutFileInFolder(argAmazonS3Request);
                GetPreSignedUrlRequest getPreSignedUrlRequest = new GetPreSignedUrlRequest();
                getPreSignedUrlRequest.BucketName = argAmazonS3Request.BucketName + "/" + argAmazonS3Request.FolderName;
                getPreSignedUrlRequest.Key = m_ObjectKey;
                getPreSignedUrlRequest.Expires = DateTime.Now.AddHours(1);
                getPreSignedUrlRequest.Protocol = Protocol.HTTP;
                l_Url = AmazonS3ClientObject.GetPreSignedURL(getPreSignedUrlRequest);
                argAmazonS3Request.PreSignedPublicUrl = l_Url;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                AmazonS3ClientObject.Dispose();
                AmazonS3ClientObject = null;
            }
        }
