    public bool BuildTree(string directory, string searchItem = null, List<string> matches = null, string searchField = null)
        {
            if (!Directory.Exists(directory))
                return false;
            _directoryCache = BuildDirectoryCache(directory, searchItem, matches, searchField);
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(directory);
            
            FileInfo[] list1 = dir1.GetFiles("*.sessZip", System.IO.SearchOption.AllDirectories);
            _directoryCache.FileInfoLst = list1;
            return true;
        }
