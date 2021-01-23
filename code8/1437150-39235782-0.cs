    public bool VerifyCacheIntegrity()
        {
            if (_directoryCache == null || string.IsNullOrEmpty(_directoryCache.DirectoryName))
                return false;
            System.IO.DirectoryInfo dir1 = new System.IO.DirectoryInfo(_directoryCache.DirectoryName);
            FileInfo[] list1 = dir1.GetFiles("*.sessZip", System.IO.SearchOption.AllDirectories);
            
            FileCompare myFileCompare = new FileCompare();
            
            return list1.SequenceEqual(_directoryCache.FileInfoLst, myFileCompare); 
            
        }
