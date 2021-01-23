            SqlBulkCopyOptions options = SqlBulkCopyOptions.KeepIdentity;
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destConnection.ConnectionString, options))
            {
                bulkCopy.DestinationTableName = destTableName;
                    // Write from the source to the destination.
                bulkCopy.WriteToServer(reader);
            }
