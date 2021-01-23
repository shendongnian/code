    public bool RemoveShare(string username, string password, string ipAddress, string sharename)
    {
        bool result = false;
    
        try
        {
            // Create management scope and connect to the remote machine
            ConnectionOptions options = new ConnectionOptions();
            options.Username = username;
            options.Password = password;
            string path = string.Format(@"\\{0}\root\cimv2", ipAddress);
            ManagementScope scope = new ManagementScope(path, options);
            scope.Connect();
    
            // Inspiration from here: https://danv74.wordpress.com/2011/01/11/list-network-shares-in-c-using-wmi/
            var query = new ObjectQuery(string.Format("select * from win32_share where Name=\"{0}\"", sharename));
            var finder = new ManagementObjectSearcher(scope, query);
            var shares = finder.Get();
    
            foreach (ManagementObject share in shares)
            {
                share.Delete();
            }
    
            mDisplay.appendToResults("Share deleted");
            result = true;
        }
        catch (Exception ex)
        {
            mDisplay.showError("FAILED to remove share: " + ex.Message.ToString());
        }
    
        return result;
    }
