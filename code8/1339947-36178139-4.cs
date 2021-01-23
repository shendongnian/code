    int batchSize = 100;
    System.Text.StringBuilder sb = new System.Text.StringBuilder();
    connection.Open();
    transaction.Begin();
    for(int i = 0; i < Count;++i)
    { 
         sb.Append("SQL-Insert");
         if(i%batchSize == 0 && i != 0)
         {
              execute(sb.ToString())
              sb.Length = 0;
         }
    }
    execute(sb.ToString())
    transaction.commit();
    // TODO: Try/Catch + Rollback
    connection.Close();
