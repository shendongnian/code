    try
    {
        // don't add LDAP://, the protocol is already known ...
        LdapConnection ldapConnection = new LdapConnection("127.0.0.1:10389");
        // notice we don't use the domain here
        var networkCredential = new NetworkCredential(
              "uid=yourusername,dc=example,dc=com", 
              "yourpassword");
        // Apache Directory Server uses LDAPv3
        ldapConnection.SessionOptions.ProtocolVersion = 3;
        // 10389 is the plain port, no ssl needed
        //ldapConnection.SessionOptions.SecureSocketLayer = true;
        // ldapConnection.SessionOptions.VerifyServerCertificate += delegate { return true; };
        // let's not negoiate, only Basic is supported
        ldapConnection.AuthType = AuthType.Basic;
        ldapConnection.Bind(networkCredential);
    }
    catch (Exception e)
    {
         Console.WriteLine(e.Message);
    }
