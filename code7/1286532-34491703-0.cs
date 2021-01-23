    double parsedValue = double.Parse(valueFromRequest);
    //be careful, this will throw if the user didn't enter a valid double.
    string connectionString = yourConnectionString;
    using (OdbcConnection connection = new OdbcConnection(connectionString))
    {
        connection.Open();
        using (OdbcCommand command = new OdbcCommand(
            "INSERT INTO datas columnName VALUES(@value)", connection))
        {
            command.Parameters.AddWithValue("@value", parsedValue);
            command.ExecuteNonQuery();
        }
    }
