    public string GetConnectionString()
    {
        string old = GetOldConnectionString();
        var csb = new System.Data.SqlClient.SqlConnectionStringBuilder(old);
        csb.Password = MyOrg.CryptStrings.DeCrypt(csb.Password);
        return csb.ConnectionString;
    }
