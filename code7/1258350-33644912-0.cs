    using (var command = new SqlCommand("dbo.test", connection) {    
    CommandType = CommandType.StoredProcedure })
    {
          connection.Open();
          Console.WriteLine("ConnectionTimeout: {0}", 
          connection.ConnectionTimeout);
          command.CommandTimeout = 120;
          command.ExecuteNonQuery();
          Console.WriteLine("Finished");
          connection.Close();
    }
