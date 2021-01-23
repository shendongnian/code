    // do all your calculations and write the data to be updated to a custom object
    List<CustomObjectWithUpdatedValues> DataToUpdateList = GetDataToUpdate();
    
    // create a transaction scope incase something fails we can rollback
    using (TransactionScope tranScope = new TransactionScope())
    {
        using (SqlConnection conn = new SqlConnection("connection_string"))
        {
            // open the connnection
            conn.Open();
    
            // create a table to temporarily hold the data to update
            string strTableName = "temp_BulkUpdateBillings";
            SqlCommand cmdCreateTable = new SqlCommand
                (
                    "CREATE TABLE " + strTableName + " " +
                        "(" +
                            "BillingID int NOT NULL, " +
                            "Field1 int NOT NULL, " +
                            "Field2 int NOT NULL, " +
                            "Field3 decimal(19, 4) NOT NULL, " +
                            "Field4 decimal(19, 4) NOT NULL, " +
                            "Field5 decimal(19, 4) NOT NULL " +
                        ")"
                , conn);
            cmdCreateTable.ExecuteNonQuery();
    
            // do sql bulk copy to insert data into new table
            using (SqlBulkCopy bcp = new SqlBulkCopy(conn))
            {
                using (var reader = ObjectReader.Create(DataToUpdateList, "BillingID", "Field1", "Field2", "Field3", "Field4", "Field5"))
                {
                    bcp.DestinationTableName = strTableName;
                    bcp.BatchSize = 1000;
                    bcp.BulkCopyTimeout = 300;
                    bcp.WriteToServer(reader);
                }
            }
    
            // update the live records
            SqlCommand cmdBulkUpdate = new SqlCommand
                (
                    "UPDATE Billings SET " +
                        "Field1 = temp.Field1, " +
                        "Field2 = temp.Field2, " +
                        "Field3 = temp.Field3, " +
                        "Field4 = temp.Field4, " +
                        "Field5 = temp.Field5 " +
                    "FROM " + strTableName + " as temp " +
                    "WHERE Billings.ID = temp.BillingID"
                , conn);
            cmdBulkUpdate.ExecuteNonQuery();
    
            // drop the table
            SqlCommand cmdDropTable = new SqlCommand("DROP TABLE " + strTableName, conn);
            cmdDropTable.ExecuteNonQuery();
        }
    
        // complete the transaction scope
        tranScope.Complete();
    }
