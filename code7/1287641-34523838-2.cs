        private static void PerformFileCopy(string DirectoryToSearch, string BaseDirectory = @"D:\")
        {
            if (Directory.Exists(BaseDirectory))// check for existance of base directory to avoid throwing exception
            {
                var searchDir = Directory.GetDirectories(BaseDirectory).Where(x => new DirectoryInfo(x).Name == DirectoryToSearch).ToList();
                string copyToLocation = @"E:\newDir";
                if (searchDir.Count > 0) // True if such directory found
                {
                    foreach (var file in Directory.GetFiles(searchDir[0])) // will iterate if Directory has files
                    {
                        File.Copy(file, copyToLocation, true);
                    }
                }
            }
        }
