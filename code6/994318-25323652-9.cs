     DataTable dtInsertRows = GetDataTable(); 
      
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand("sp_BatchInsert", connection);
        command.CommandType = CommandType.StoredProcedure;
        command.UpdatedRowSource = UpdateRowSource.None;
      
        // Set the Parameter with appropriate Source Column Name
        command.Parameters.Add("@PersonId", SqlDbType.Int, 4, dtInsertRows.Columns[0].ColumnName);   
        command.Parameters.Add("@PersonName", SqlDbType.VarChar, 100, dtInsertRows.Columns[1].ColumnName);
        
        SqlDataAdapter adpt = new SqlDataAdapter();
        adpt.InsertCommand = command;
        // Specify the number of records to be Inserted/Updated in one go. Default is 1.
        adpt.UpdateBatchSize = 2;
        
        connection.Open();
        int recordsInserted = adpt.Update(dtInsertRows);   
        connection.Close();
