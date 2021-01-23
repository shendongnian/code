    private bool AuthenticateAD(string userName, string password, string domain, out string message)
    {
        
        message = "";       
        DirectoryEntry entry = new
            DirectoryEntry("LDAP://" + domain, userName, password);
        try
        {
            object obj = entry.NativeObject;
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + userName + ")";
            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();
            if (null == result)
            {
                return false;
            }           
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return false;
            //throw new Exception("Error authenticating user. " + ex.Message);
        }
        return true;
    }
