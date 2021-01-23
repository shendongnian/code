    using(var command = new SqlCommand("pgwp_teamtypeselect", connection))
    {
      command.CommandType = CommandType.StoredProcedure;
      using(var dataReader = command.ExecuteReader())
      {
        while (dataReader.Read()) 
        {
              using(var command1 = new SqlCommand("pgwp_goalselect",  
                           connection))
               {
                 command1.CommandType = CommandType.StoredProcedure;
                 using(var dataReader2 =command1.ExecuteReader())
                 {
                 }
               }
        }
    }
