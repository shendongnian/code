      public bool CopyFolderInsideS3Bucket(string source, string destination)
            {
                var strippedSource = source;
                var strippedDestination = destination;
    
                // process source
                if (strippedSource.StartsWith("/"))
                    strippedSource = strippedSource.Substring(1);
                if (strippedSource.EndsWith("/"))
                    strippedSource = source.Substring(0, strippedSource.Length - 1);
    
                var sourceParts = strippedSource.Split('/');
                var sourceBucket = sourceParts[0];
    
                var sourcePrefix = new StringBuilder();
                for (var i = 1; i < sourceParts.Length; i++)
                {
                    sourcePrefix.Append(sourceParts[i]);
                    sourcePrefix.Append("/");
                }
    
                // process destination
                if (strippedDestination.StartsWith("/"))
                    strippedDestination = destination.Substring(1);
                if (strippedDestination.EndsWith("/"))
                    strippedDestination = destination.Substring(0, strippedDestination.Length - 1);
    
                var destinationParts = strippedDestination.Split('/');
                var destinationBucket = destinationParts[0];
    
                var destinationPrefix = new StringBuilder();
                for (var i = 1; i < destinationParts.Length; i++)
                {
                    destinationPrefix.Append(destinationParts[i]);
                    destinationPrefix.Append("/");
                }
    
                var listObjectsResult = client.ListObjects(new ListObjectsRequest(){ 
                    BucketName = sourceBucket,
                    Prefix = sourcePrefix.ToString(),
                    Delimiter = "/"});
    
                // copy each file
                foreach (var file in listObjectsResult.S3Objects)
                {
                    var request = new CopyObjectRequest();
                    request.SourceBucket = Settings.BucketName;
                    request.SourceKey = file.Key;
                    request.DestinationBucket = destinationBucket;
                    request.DestinationKey = destinationPrefix + file.Key.Substring(sourcePrefix.Length);
                    request.CannedACL = S3CannedACL.PublicRead;
                    var response = (CopyObjectResponse)client.CopyObject(request);
                }
    
                // copy subfolders
                foreach (var folder in listObjectsResult.CommonPrefixes)
                {
                    var actualFolder = folder.Substring(sourcePrefix.Length);
                    actualFolder = actualFolder.Substring(0, actualFolder.Length - 1);
                    CopyFolderInsideS3Bucket(strippedSource + "/" + actualFolder, strippedDestination + "/" + actualFolder);
                }
    
                return true;
            }
