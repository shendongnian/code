    public static bool login(string domain, System.Net.NetworkCredential cred)
    {
        try
        {
            LdapConnection conn = new LdapConnection(domain);
            conn.Bind(cred);
            return true; 
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
