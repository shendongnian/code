    SqlConnection insSqlConnection = new SqlConnection("YOUR CONNECTION STRING HERE");
    SqlCommand insSqlCommand = new SqlCommand("MyStoredProcedure", insSqlConnection);
    insSqlCommand.CommandType = CommandType.StoredProcedure;
    SqlDataAdapter insSqlDataAdapter = new SqlDataAdapter(insSqlCommand);
    DataTable insDt = new DataTable();
    insSqlDataAdapter.Fill(insDt);
    insSqlConnection.Close();
