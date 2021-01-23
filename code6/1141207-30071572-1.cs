    DirectoryEntry dirEntry = new DirectoryEntry("LDAP://DC=company,DC=com");
    DirectorySearcher search = new DirectorySearcher(dirEntry);
    search.PropertiesToLoad.Add("cn");
    search.PropertiesToLoad.Add("displayName");
    search.PropertiesToLoad.Add("manager");
    search.PropertiesToLoad.Add("mail");
    search.PropertiesToLoad.Add("sAMAccountName");
    if (username.IndexOf('@') > -1)
    {
        // userprincipal username
        search.Filter = "(userPrincipalName=" + username + ")";
    }
    else
    {
        // samaccountname username
        String samaccount = username;
        if (username.IndexOf(@"\") > -1)
        {
            samaccount = username.Substring(username.IndexOf(@"\") + 1);
        }
        search.Filter = "(sAMAccountName=" + samaccount + ")";
    }
    SearchResult result = search.FindOne();
    result.Properties["manager"][0];
