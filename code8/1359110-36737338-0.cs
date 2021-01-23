    private DirectoryInfo PathDirectoryInfo
    {
        get
        {
            if (_directoryInfo == null)
            {
                // Some logic to create the path
                // var path = ...
                _directoryInfo = new DirectoryInfo(path);
            }
            else
            {
                _directoryInfo.Refresh();
            }
    
            return _directoryInfo;
        }
    }
