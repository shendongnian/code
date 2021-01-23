            public static void MoveFiles()
            {
                BasicAWSCredentials basicCredentials = new BasicAWSCredentials("access key", "secret key");
                AmazonS3Config configurationClient = new AmazonS3Config();
                configurationClient.RegionEndpoint = RegionEndpoint.EUCentral1;//region of bucket
                try
                {
                    using (AmazonS3Client clientConnection = new AmazonS3Client(basicCredentials, configurationClient))
                    {
                        S3DirectoryInfo source = new S3DirectoryInfo(clientConnection, "sourcebucketname", "sourcefolderkey");
                        S3DirectoryInfo target = new S3DirectoryInfo(clientConnection, "destinationbucketname", "destinationfolderkey");
                        source.MoveTo(target);// move all  content from FolderNameUniTest109 to FolderNameUniTest179
                        
                    }
                }
                catch(Exception ex)
                {
                    
                }
            
            
                
            }
