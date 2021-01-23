    SqlConnection connection = new SqlConnection(youCconnectionString);
    connection.Close(); 
    connection.Open();
    SqlCommand command = new SqlCommand("YourQuery", connection);
    command.CommandType = CommandType.Text;
    command.ExecuteNonQuery();
    connection.Close();
    command.Dispose();
