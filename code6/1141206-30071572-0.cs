    DirectoryEntry dirEntry = new DirectoryEntry("LDAP://DC=company,DC=com");
    DirectorySearcher search = new DirectorySearcher(dirEntry);
    search.PropertiesToLoad.Add(LdapUtils.CN_ATTR_NAME);
    search.PropertiesToLoad.Add("displayName");
    search.PropertiesToLoad.Add("manager");
    search.PropertiesToLoad.Add("mail");
    search.PropertiesToLoad.Add("sAMAccountName");
    if (username.IndexOf('@') > -1)
    {
        // userprincipal prijava
        search.Filter = "(" + LdapUtils.USERPRINCIPAL_ATTR_NAME + "=" + username + ")";
    }
    else
    {
        // samaccountname prijava
        String samaccount = username;
        if (username.IndexOf(@"\") > -1)
        {
            samaccount = username.Substring(username.IndexOf(@"\") + 1);
        }
        search.Filter = "(" + LdapUtils.SAMACCOUNTNAME_ATTR_NAME + "=" + samaccount + ")";
    }
    SearchResult result = search.FindOne();
    result.Properties["manager"][0].ToString();
