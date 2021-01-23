    using(SqlConnection connection = new SqlConnection("Server..."))
    {
      SqlCommand command = connection.CreateCommand();
      command.CommandText = "insert into Records values (...)";
      connection.Open();
      int craeted = command.ExecuteNonQuery();
    }
