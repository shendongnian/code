        public static void list_file()
        {
            //***** Get list of all files/directories on the file share*****//
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("xxxxxxxxxxxxxxxxxxxxxx_AzureStorageConnectionString"));
            CloudFileClient fileClient = cloudStorageAccount.CreateCloudFileClient();
            CloudFileShare fileShare = fileClient.GetShareReference("dummyfile");
            // List all files/directories under the root directory.
            Console.WriteLine("Getting list of all files/directories under the root directory of the share.");
            IEnumerable<IListFileItem> fileList = fileShare.GetRootDirectoryReference().ListFilesAndDirectories();
            // Print all files/directories listed above.
            foreach (IListFileItem listItem in fileList)
            {
                // listItem type will be CloudFile or CloudFileDirectory.
                Console.WriteLine(listItem.Uri.Segments.Last());
                Console.WriteLine(listItem.GetType());
                if(listItem.GetType()== typeof(Microsoft.WindowsAzure.Storage.File.CloudFileDirectory))
                {
                    
                    list_subdir(listItem);
                }
            }
        }
        public static void list_subdir(IListFileItem list)
        {
            Console.WriteLine("subdir");
            CloudFileDirectory fileDirectory=(CloudFileDirectory)list;
            IEnumerable<IListFileItem> fileList = fileDirectory.ListFilesAndDirectories();
            // Print all files/directories in the folder.
            foreach (IListFileItem listItem in fileList)
            {
                // listItem type will be CloudFile or CloudFileDirectory.
                Console.WriteLine(listItem.Uri.Segments.Last());
            }
        }
