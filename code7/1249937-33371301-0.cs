    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
      connection.Open();
      //Do some work
    }//The connection is automatically closed when the code exits the using block.
