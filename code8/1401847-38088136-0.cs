    BasicAWSCredentials basicCredentials = new BasicAWSCredentials("yoursecretkey", "youraccesskey");
            AmazonS3Config configurationClient = new AmazonS3Config();
            configurationClient.RegionEndpoint = RegionEndpoint.EUCentral1;// region of your bucket
            try
            {
                using (AmazonS3Client clientConnection = new AmazonS3Client(basicCredentials, configurationClient))
                {
                    S3DirectoryInfo source = new S3DirectoryInfo(clientConnection, "yourbucket");
                                
                    var query = source.GetFiles("*", System.IO.SearchOption.AllDirectories).GroupBy( fi => fi.LastWriteTime.ToString("dd/MM/yyyy")).Select(group => new { LastDateModify = group.Key, Count = group.Count()}).OrderBy( fi => fi.LastDateModify);
                    int age = 1;
                    foreach (var amazonFile in query)
                    {
                        Console.WriteLine(string.Format("DATEOFSERVICE:{0} AGE:{1} COUNT:{2}", amazonFile.LastDateModify, age, amazonFile.Count));
                        age++;
                    }
                }
            }
            catch (Exception ex)
            {
                // add the properly handling exception
            }
