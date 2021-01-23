    var commandSB = new StringBuilder();
    int batchCount = 0;
    using (var updateCommand = sourceConnection.CreateCommand())
    {
        foreach (var item in UsageRecords)
        {
            commandSB.AppendFormat(@"
                UPDATE tbl810CTImport 
                SET MthlyConsumption = @MthlyConsumption{0}
                WHERE ID = @ID{0}", 
                batchCount
            );
            updateCommand.Parameters.AddWithValue(
                "@MthlyConsumption" + batchCount,
                item.MthlyConsumption
            );
            updateCommand.Parameters.AddWithValue(
                "@ID" + batchCount,
                item.MthlyConsumption
            );
            if (batchCount == 500) {
                updateCommand.CommandText = commandSB.ToString();
                updateCommand.ExecuteNonQuery();
                commandSB.Clear();
                updateCommand.Parameters.Clear();
                batchCount = 0;
            }
            else {
                batchCount++;
            }
        }
        if (batchCount != 0) {
            updateCommand.ExecuteNonQuery();
        }
    }
