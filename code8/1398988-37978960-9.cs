     using (SqlConnection connection = new SqlConnection(""))
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
        adapter.Update(dsControlSheet.Tables[0]);
    }
 
