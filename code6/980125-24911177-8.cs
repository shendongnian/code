    public static string constr = null;
    
    public string GetConnectionString()
    {
        if(constr != null)
            return constr;
    
        string old = GetOldConnectionString();
        var csb = new System.Data.SqlClient.SqlConnectionStringBuilder(old);
        csb.Password = MyOrg.CryptStrings.DeCrypt(csb.Password);
        constr = csb.ConnectionString;
        return constr;
    }
