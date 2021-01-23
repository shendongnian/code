    using(var connection = new OleDbConnection(connString))
    using(var command = connection.CreateCommand())
    {
          // Set your CommandText property.
          // Add parameters with `Add` method
          using(var reader = cmd.ExecuteReader())
          {
              while (reader.Read())
              {
                   // Get your values.
                   // Clear your parameters with `Parameters.Clear()` method.
                   // Add new parameters to `cmd`
                   // Execute your query.
              }
          }
    }
