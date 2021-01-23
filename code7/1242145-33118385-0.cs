    using(var conn5 = new OleDbConnection(connString))
    using(var command = conn5.CreateCommand())
    {
          // Define your CommandText
          using(var reader = command.ExecuteReader())
          {
              while (reader.Read())
              {
                   // Do other stuff
              }
          }
    }
