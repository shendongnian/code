    protected string ldapAuthentication(string strLDAPServer, string strSuppliedUser, string strSuppliedPwd, string strSystemUID, string strSystemPwd, string strLDAPUserBase, string strUIDAttr){
    	strSuppliedUser = strSuppliedUser.Trim();
	string strResults = "";
        string strLDAPUserHost = strLDAPServer + strLDAPUserBase;
        // Establish LDAP connection and bind with system ID
        System.DirectoryServices.DirectoryEntry dirEntry = new System.DirectoryServices.DirectoryEntry();
        dirEntry.Path = strLDAPUserHost;
        dirEntry.Username = strSystemUID;
        dirEntry.Password = strSystemPwd;
	dirEntry.AuthenticationType = System.DirectoryServices.AuthenticationTypes.SecureSocketsLayer;
        try
        {
            dirEntry.RefreshCache();
            // Search directory for the user logging on
            string strLDAPFilter = "(&(objectClass=user)(" + strUIDAttr + "=" + strSuppliedUser + "))";
            System.DirectoryServices.DirectorySearcher ldapSearch = new System.DirectoryServices.DirectorySearcher(dirEntry);
            ldapSearch.ServerTimeLimit = new TimeSpan(0, 0, 30);
            
            ldapSearch.Filter = strLDAPFilter;
            ldapSearch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
            System.DirectoryServices.SearchResultCollection searchResults = ldapSearch.FindAll();
            
		
            if (searchResults.Count == 1){
            ...
