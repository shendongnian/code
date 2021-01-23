        var pk = "abc";
        var filterPk = TableQuery.GenerateFilterCondition(
            nameof(ServiceAlertsEntity.PartitionKey),
            QueryComparisons.Equal, pk);
                    
        var query = new TableQuery<ServiceAlertsEntity>().Where(filterPk);
