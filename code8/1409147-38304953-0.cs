    var transaction = odbc.dbsqlite.BeginTransaction();
    int count = 0;
    while(read)
    {
      count++;
      if(count % 1000 == 0)
      {
         transaction.Commit();
         transaction = odbc.dbsqlite.BeginTransaction();
      }
      //I imagine this CreateCommand() is assigning connection...
      using(var cmd = odbc.dbsqlite.CreateCommand())
      {
         cmd.CommandText = "INSERT...";
         //Params...
         cmd.Transaction = transaction;
         cmd.ExecuteNonQuery();
      }
    }
