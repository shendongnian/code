        static void Main(string[] args)
        {
            ScanDisksForSize(new DirectoryInfo(@"C:\Users"));
            Console.ReadLine();
        }
        static void ScanDirectoriesForSize(DirectoryInfo topDir)
        {
            long sizeOfDir;
            if (topDir != null)
                sizeOfDir = DiskSize(topDir);
            else
                return;
            Console.WriteLine("Size on disk of {0}: {1:N2} MB", topDir.Name, ((double)sizeOfDir) / (1024 * 1024));
            //Do subfolders
            var subFolders = topDir.GetDirectories();
            if (subFolders == null)
                return;
            foreach (var folder in subFolders)
                ScanDisksForSize(folder);
        }
        static long DiskSize(DirectoryInfo dInfo)
        {
            try
            {   
                long totalSize = dInfo.EnumerateFiles().Sum(file => file.Length);
            return totalSize;
            }
            catch (Exception)
            {
                return 0;
            }
        }
