     //Bulk copy datatable to DB
     SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionStr);
     try
     {
         columns.ForEach(col => { bulkCopy.ColumnMappings.Add(col, col); });
         bulkCopy.DestinationTableName = tableName;
         bulkCopy.WriteToServer(dt);
     }
     catch (Exception ex)
     {
         throw ex;
     }
     finally
     {
         bulkCopy.Close();
     }
