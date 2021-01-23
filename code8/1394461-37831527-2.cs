    public static String ChangeUserPassword(String adminName, String adminPassword, String userName, String currentPassword, String newPassword, String domainController, String container)
    {
        String ldapPath = String.Format("LDAP://{0}/{1}", domainController, container); // this is your domain name
        DirectoryEntry de = new DirectoryEntry(ldapPath, adminName, adminPassword, AuthenticationTypes.Secure);
        DirectorySearcher ds = new DirectorySearcher(de);
        String query = String.Format("(&(objectCategory=person)(sAMAccountName={0}))", userName);
        ds.Filter = query;
        ds.Sort.PropertyName = "CN";
        ds.SearchScope = SearchScope.Subtree;
        ds.CacheResults = false;
        try
        {
            SearchResult sr = ds.FindOne();
            if (sr == null)
            {
                return "User name not found in this domain.";
            }
            DirectoryEntry userCredentials = sr.GetDirectoryEntry();
            user.Invoke("ChangePassword", new Object[] { newPassword });
            user.CommitChanges();
            return "Password for " + userName + "changed successfully.";
        }
        catch (Exception e)
        {
           // throw exception here
           return "An error occurred when trying to connect on LDAP service.";
        }
    }
