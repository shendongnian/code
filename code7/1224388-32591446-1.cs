    using((OleDbConnection connection = new OleDbConnection(dbConnection))
         using(OleDbCommand command = new OleDbCommand(query, connection))
         {
              connection.Open();    
              // Parameter(s) here
              command.ExecuteNonQuery();
              // Any other logic here.
         }
