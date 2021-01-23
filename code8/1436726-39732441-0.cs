            AmazonS3Config cfg = new AmazonS3Config();
            cfg.RegionEndpoint = Amazon.RegionEndpoint.EUCentral1;//my bucket has this Region
            string bucketName = "your bucket";
            AmazonS3Client s3Client = new AmazonS3Client("your access key", "your secret key", cfg);
            S3FileInfo sourceFile = new S3FileInfo(s3Client, bucketName, "FolderNameUniTest179/Test.test.test.pdf");
            S3DirectoryInfo targetDir = new S3DirectoryInfo(s3Client, bucketName, "Test");           
            sourceFile.CopyTo(targetDir);
            S3FileInfo sourceFile2 = new S3FileInfo(s3Client, bucketName, "FolderNameUniTest179/Test...pdf");
            sourceFile2.CopyTo(targetDir);
