    static DirectoryEntry CreateDirectoryEntry(string connectionPath)
    {
        DirectoryEntry ldapConnection = null;
    
        try
        {
            ldapConnection = new DirectoryEntry(AD_DOMAIN_NAME)
            ldapConnection.Path = connectionPath;
            ldapConnection.AuthenticationType = AuthenticationTypes.Secure;
        }
    
        catch (Exception ex)
        {
            MessageBox.Show("Exception Caught in createDirectoryEntry():\n\n" + ex.ToString());
        }
    
        return ldapConnection;
    } 
