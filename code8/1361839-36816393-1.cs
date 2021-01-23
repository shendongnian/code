    using (SqlConnection connection = new SqlConnection(connectionString))
    {
         connection.Open();
         SqlTransaction transaction = connection.BeginTransaction();
 
         using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
         {
            bulkCopy.BatchSize = 100;
            bulkCopy.DestinationTableName = "dbo.FEATURES";
            try
            {
                // define mappings for columns, as property names / generated data table column names
                // is different from destination table column name
                bulkCopy.ColumnMappings.Add("ID","UserID");
                bulkCopy.ColumnMappings.Add("Angle","Angle");
                // the other mappings come here
                bulkCopy.WriteToServer(Details.modelKeyPoints.AsDataTable());
            }
            catch (Exception)
            {
                transaction.Rollback();
                connection.Close();
            }
          }
 
          transaction.Commit();
    }
