    MySqlConnection connection = new MySqlConnection(connectionString);
    connection.Open();    
    MySqlCommand command = new MySqlCommand("SELECT * FROM mail WHERE fromuser = @fromUser", connection);
    cmd.Parameters.Add(new MySqlParameter("fromUser", lblUsername.Text)); 
    MySqlDataReader dataReader = cmd.ExecuteReader();
    if (dataReader.HasRows){
    //do all your reading.
    }
    connection.Close();
