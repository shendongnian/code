    TableQuery<ServiceAlertsEntity> query = new TableQuery<ServiceAlertsEntity>();
        
    foreach (ServiceAlertsEntity entity in table.ExecuteQuery(query))
    {
        Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                            entity.Field1, entity.Field2);
    }
