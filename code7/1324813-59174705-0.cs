        public void DeleteOutputDirectory()
        {
            var share = _fileClient.GetShareReference(_settings.FileShareName);
            var rootDir = share.GetRootDirectoryReference();
            
            DeleteDirectory(rootDir.GetDirectoryReference("DirName"));
        }
        private static void DeleteDirectory(CloudFileDirectory directory)
        {
            if (directory.Exists())
            {
                foreach (IListFileItem item in directory.ListFilesAndDirectories())
                {
                    switch (item)
                    {
                        case CloudFile file:
                            file.Delete();
                            break;
                        case CloudFileDirectory dir:
                            DeleteDirectory(dir);
                            break;
                    }
                }
                directory.Delete();
            }
        }
