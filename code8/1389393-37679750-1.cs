    public static writeConsole(string query, string connectionString, string driver)
    {
        //driver = Oracle.ManagedDataAccess.Client
        using (var conn = DbProviderFactories.GetFactory(driver).CreateConnection())
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.Connection.ConnectionString = connectionString;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = query;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0]+"");
                }
            }
        }
    }
