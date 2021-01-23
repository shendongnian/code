    using (var sourceConnection = new SqlConnection(sourceConnectionString))
    using (var destinationConnection = new SqlConnection(destinationConnectionString))
    {
        sourceConnection.Open();
        destinationConnection.Open();
        var createTableQuery = "create table #t (id uniqueidentifier, name nvarchar(100), adresse(nvarchar(100))";
        using (var createTableCommand = new SqlCommand(createTableQuery, destinationConnection))
        {
            createTableCommand.ExecuteNonQuery();
        }
        using (var selectCommand = new SqlCommand("SELECT id, name, adresse FROM table1"))
        using (var selectReader = selectCommand.ExecuteReader())
        using (var destBulkInsert = new SqlBulkCopy(destinationConnection))
        {
            destBulkInsert.DestinationTableName = "#t";
            destBulkInsert.WriteToServer(selectReader);
        }
        var mergeQuery = "INSERT INTO table2(id, name, adresse) SELECT * FROM #t WHERE #t.id NOT IN(SELECT id FROM table2)";
        using (var mergeCommand = new SqlCommand(mergeQuery, destinationConnection))
        {
            mergeCommand.ExecuteNonQuery();
        }
    }
