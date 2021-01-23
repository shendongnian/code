    string connStr = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=<hostname>)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=<service_name>)));User Id=<user>;Password=<password>";
    Console.WriteLine("Connection string has length " + connStr.Length);
    using (var connection = new OracleConnection() { ConnectionString = connStr })
    {
        connection.Open();
        OracleCommand command = new OracleCommand("SELECT * FROM DUAL", connection);
        using (OracleDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }
        }
    }
