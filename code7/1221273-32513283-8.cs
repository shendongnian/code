    var builder = new SqlConnectionStringBuilder();
    builder.DataSource = "tcp:" + serverName + ".database.windows.net,1433";
    builder.InitialCatalog = databaseName;
    builder.UserID = userId;
    builder.Password = password;
    builder.Encrypt = true;
    builder.TrustServerCertificate = false;
    builder.ConnectTimeout = 30;
    var count = "";
    var cmdText = "SELECT Count(*) FROM information_schema.columns";
    using (var conn = new SqlConnection(builder.ConnectionString))
    {
        conn.Open();
        using (var cmd = new SqlCommand(cmdText, conn))
        {
            count = cmd.ExecuteScalar().ToString();
        }
        conn.Close();
    }
    Console.WriteLine();
    Console.WriteLine("The query returned {0} rows.", count);
