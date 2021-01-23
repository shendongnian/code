    using (OracleConnection connection = new OracleConnection(connectionString)){
        using (OracleCommand command = new OracleCommand(sql, connection))
            using (OracleDataReader reader = cmd.ExecuteReader())
            {
            }
        connection.Close(); //optional
    }
