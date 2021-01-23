    using (SqlDataAdapter adapter = new SqlDataAdapter())
    {
      SqlConnection connection = new SqlConnection("Server...");
      connection.Open();
      string command = "insert into Records values (...)";
      adapter.InsertCommand = new SqlCommand(command, connection);
      adapter.InsertCommand.ExecuteNonQuery(); 
    }
