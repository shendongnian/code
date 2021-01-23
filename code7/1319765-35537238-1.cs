    var rowKeyToUse = string.Format("{0:D19}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
    
    var q1 =
      (from entity in table.CreateQuery<DynamicTableEntity>()
       where entity.PartitionKey == "TestPartition"
       && string.Compare(entity.RowKey, rowKeyToUse, StringComparison.Ordinal) > 0
       select entity).AsTableQuery();
    
    TableContinuationToken continuationToken = null;
    do
    {
        var counter = 0;
        var queryResult = q1.ExecuteSegmented(continuationToken);
    
        foreach (var entity in queryResult)
        {
    	Console.WriteLine("[" + entity.RowKey + "]"
    	     + ++counter
    	     );      
        }
    
        continuationToken = queryResult.ContinuationToken;
        Console.WriteLine("####" + counter);
    } while (continuationToken != null);
