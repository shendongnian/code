    using (SqlConnection YourConnection= new SqlConnection(YourConnectionString))
    {
           YourConnection.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(YourConnection))
            {
                bulkCopy.DestinationTableName = "dbo.YourDestinationTable";
    
                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(sourceTable);
                }
                catch (Exception ex) { }
            }
    }
