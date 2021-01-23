    public static string  DynamicConnectionString(SqlConnectionStringBuilder builder)
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        builder.DataSource = "ServerName";
        builder.InitialCatalog = "DatabaseName";
        builder.UserID = "UserId";
        builder.Password = "Password";
        builder.MultipleActiveResultSets = true;
        builder.PersistSecurityInfo = true;    
        return builder.ConnectionString.ToString();
    }
