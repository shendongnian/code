    var connectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = @".\SQLEXPRESS",
        AttachDBFilename = databaseLocation,
        IntegratedSecurity = true,
        ConnectTimeout = 30,
        UserInstance = true
    };
    SqlConnection cnTB = new SqlConnection(connectionStringBuilder.ToString());
