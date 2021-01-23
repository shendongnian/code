    pulic string GetDriveRoot(string computerName, string shareName)
        var scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", computerName));      
        
        scope.Connect();
        ObjectQuery query = new ObjectQuery("SELECT * FROM win32_share WHERE name = '" + shareName + "'");
        var searcher = new ManagementObjectSearcher(scope,query);
        var queryCollection = searcher.Get();
        foreach (ManagementObject m in queryCollection)
        {
            var path = m["Path"];
            return Directory.GetDirectoryRoot(path);
        }
        return null;
    }
