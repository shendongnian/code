    public static bool CheckForDatabase()
    {
        using ( var sqlConnection = new SqlConnection( ConfigurationManager.ConnectionStrings["YourConnectionStringNameFromWebConfig"].ConnectionString))
        {
            var sqlCommand = new SqlCommand
            {
                CommandText = "Select * from sys.databases Where name = 'DEV_WebSystems2'",
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };
            sqlConnection.Open();
            using (var reader = sqlCommand.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    return true;
                }
            }
            return false;
        }
    }
    public static bool Create()
    {
        try
        {
            using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["YourConnectionStringNameFromWebConfig"].ConnectionString))
            {
                FileInfo file = new FileInfo(@"C:\Users\yourName\Desktop\test.sql");
                string script = file.OpenText().ReadToEnd();
                var server = new Server(new ServerConnection(sqlConnection));
                server.ConnectionContext.ExecuteNonQuery(script);
            }
            return true;
        }
        catch (Exception exception)
        {
            Log.Error(exception);
            return false;
        }
    }
