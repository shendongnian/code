     using (SqlConnection connection = new SqlConnection(connectionString))
     {
       SqlDataAdapter adapter = new SqlDataAdapter();
       var insertCommand = new SqlCommand("Insert into Category (Name, ParentId) Values (@name, @parentId);", connection);
       var parameter = insertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Name");
       insertCommand.Parameters.Add("@parentId", SqlDbType.Int, 0, "ParentId");
       adapter.insertCommand = insertCommand;
       // When setting UpdateBatchSize to a value other than 1, all the commands 
       // associated with the SqlDataAdapter have to have their UpdatedRowSource 
       // property set to None or OutputParameters. An exception is thrown otherwise.
         insertCommand.UpdatedRowSource = UpdateRowSource.None;
       // Gets or sets the number of rows that are processed in each round-trip to the server.
       // Setting it to 1 disables batch updates, as rows are sent one at a time.
        adapter.UpdateBatchSize = 50;
        //NOTE: When doing batch updates it's a good idea to fine tune CommandTimeout value
        //since default is 30 seconds. If your batch insert takes more than 30 s (default value)
        //then make sure to increase this value. I am setting this to 90 s
        //but you must decide this based on your situation.
        //Set this to 0 if you are not sure how long your batch inserts will take
        insertCommand.CommandTimeout = 90;
    
        //HOW TO MAKE BATCH INSERTS FASTER IN PERFORMANCE
        //Perform batch updates in a single transaction to increase batch insert performance
        connection.Open();
        var transaction = connection.BeginTransaction();
        insertCommand.Transaction = transaction;
        try { 
             adapter.Update(dsControlSheet.Tables[0]);
             transaction.Commit();
        }
        catch(Exception e) {
    
        if(transaction!=null) {
           transaction.Rollback();
         }
         //log exception
       }
       finally {
          connection.Close();
       }
    }
