    string commandText = "UPDATE Sales.Store SET Demographics = @demographics "
        + "WHERE CustomerID = @ID;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        SqlCommand command = new SqlCommand(commandText, connection);
        command.Parameters.Add("@ID", SqlDbType.Int);
