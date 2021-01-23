    // make sure the server and port are correct
    using (var ldap = new LdapConnection("ldap.company.com:3060"))
    {
        // make sure to pass the username as a distinguishedName
        var dn = string.Format("cn={0},cn=users,dc=company,dc=com", username);
        // passing null for the domain worked for me
        var credentials = new System.Net.NetworkCredential(dn, password, null);
        ldap.AuthType = AuthType.Basic;
    
        try
        {
            ldap.Bind(credentials);
            return true;
        }
        catch (LdapException ex)
        {
            return false;
        }
    }
