        public async Task<TEntity> Retrieve<TEntity>(string tableReference, string partitionKey, string rowKey) : where TEntity : ITableEntity
        {
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableReference);
            TableOperation retrieveOperation = TableOperation.Retrieve<TEntity>(partitionKey, rowKey);
            TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
            return (TEntity)retrievedResult.Result;
        }
