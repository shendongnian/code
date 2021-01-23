    using(var command = new SqlCommand(salesQuery, connection))
    {
      using(var dataReader = dbConnectivity.command.ExecuteReader())
      {
        while (dataReader.Read()) {
              using(var dataReader2 =command2.ExecuteReader())
              {
              }
      }
    }
