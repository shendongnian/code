    using (DirectoryEntry de = new DirectoryEntry(ldap://mydomain.com:389, LDAPUser, LDAPPass, authflags))
    {
        try
        {
            Object obj = de.NativeObject;
        }
        catch (Exception ex)
        {
            ErrorMsg = ex.Message;
        }
    }
