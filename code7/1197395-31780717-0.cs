    using (var sourceConnection = new SqlConnection(SourceConnectionString))
    using (var sourceCommand = new SqlCommand("SELECT * FROM SourceTable", sourceConnection))
    using (var targetConnection = new SqlConnection(TargetConnectionString))
    using (var bcp = new SqlBulkCopy(targetConnection, SqlBulkCopyOptions.TableLock, null)) 
    {
        bcp.DestinationTableName = "TargetTable";
        sourceConnection.Open();
        targetConnection.Open();
        using (var sourceReader = sourceCommand.ExecuteReader())
        {
            bcp.WriteToServer(sourceReader);
        }
    }
