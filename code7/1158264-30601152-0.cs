        using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
        {
            bulkCopy.DestinationTableName = "dbo.YourDestinationTable";
            try
            {
                // Write from the source to the destination.
                bulkCopy.WriteToServer(sourceTable);
            }
            catch (Exception ex) { }
        }
