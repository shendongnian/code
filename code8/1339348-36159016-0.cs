    SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
    {
        DataSource = "SERVERWITHDB",
        InitialCatalog = "DATABASENAME",
        IntegratedSecurity = true
    };
    SqlConnection cs = new SqlConnection(connectionStringBuilder.ToString());
