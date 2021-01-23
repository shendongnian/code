    using (var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleDB"].ConnectionString))
    using (var command = new OracleCommand(query, connection))
    using (var dataAdapter = new OracleDataAdapter(command))
    using (var dataSet = new DataSet())
    {
        connection.Open();
        dataAdapter.Fill(dataSet);
        connection.Close();
        return dataSet;
    }
