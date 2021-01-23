    System.Data.SqlClient.SqlConnectionStringBuilder builder =
        new System.Data.SqlClient.SqlConnectionStringBuilder();
    builder.DataSource = "SERVERNAME";
    builder.IntegratedSecurity = true;
    builder.InitialCatalog = "DATABASE";
    builder.UserID = "userid";
    builder.Password = "password";
    Console.WriteLine(builder.ConnectionString);
