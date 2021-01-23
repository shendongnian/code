      conn = "Server=localhost;Database=testinbg;Uid=TheAdmin;Pwd=dsa67as7d66asd;";
      ...
      // Wrap IDisposable (i.e. MySqlConnection) into "using"
      using (var connect = new MySqlConnection(conn)) 
      {
        connect.Open();
    
        using (MySqlCommand cmd = new MySqlCommand()) 
        {
          cmd.Connection = connect;
          cmd.CommandText = @"INSERT INTO...";
    
          cmd.EndExecuteNonQuery();
        }
      }
