    SqlConnection insSqlConnection = new SqlConnection("Your connection string");
    SqlCommand insSqlCommand = new SqlCommand("SELECT * FROM INFORMATION_SCHEMA.TABLES", insSqlConnection);
    SqlDataAdapter insSqlDataAdapter = new SqlDataAdapter(insSqlCommand);
    DataTable insDt_Tables = new DataTable();
    insSqlConnection.Open();
    insSqlDataAdapter.Fill(insDt_Tables);
    insSqlConnection.Close();
