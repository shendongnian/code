    pulic string GetLocalPath(string computerName, string shareName)
    {
        var scope = new ManagementScope(string.Format(@"\\{0}\root\cimv2", computerName));      
        scope.Connect();
        var query = new ObjectQuery("SELECT * FROM win32_share WHERE name = '" + shareName + "'");
        var searcher = new ManagementObjectSearcher(scope,query);
        var queryCollection = searcher.Get();
        foreach (ManagementObject m in queryCollection)
        {
            return m["Path"];
        }
        return null;
    }
