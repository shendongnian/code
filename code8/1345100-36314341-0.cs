    public TableQuery<T> StorageQuery<T>(string customerId) where T : TableEntity
    {
        TableQuery<T> query = new TableQuery<T>()
            .Where(TableQuery.GenerateFilterCondition("PartitionKey", 
                QueryComparisons.Equal, customerId));
    }
