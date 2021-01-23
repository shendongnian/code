                var keyName = Globals.configSettings.AmazonS3ApiKey;
                var apiId = Globals.configSettings.AmazonS3ApiId;
                var fileName = !string.IsNullOrEmpty(ChangedFileName) ? ChangedFileName : fileUploadDownloadable.FileName;
                using (var fileTransferUtility = new TransferUtility(new AmazonS3Client(apiId, keyName, Amazon.RegionEndpoint.USEast1)))
                {
                    var bucketName = Globals.configSettings.AmazonS3ApiBucketName;                    
                    var inputStream = new MemoryStream(File.ReadAllBytes(filePath));
                    var key = "images/downloads/" + fileName;                    
                    fileTransferUtility.Upload(inputStream, bucketName, key);
                }
