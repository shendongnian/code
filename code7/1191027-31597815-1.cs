     using (SqlConnection Connection = new SqlConnection("..."))
    {
    using (SqlCommand Command = Connection.CreateCommand())
    {
        Connection.Open();
    Command.CommandText = "SELECT name,surname FROM Users WHERE ID=2";
     using (SqlDataReader reader = Command.ExecuteReader())
     {
             reader.Read();
             name = reader.GetString(0);
             surname= reader.GetString(1);
      }
    }
