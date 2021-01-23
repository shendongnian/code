        public async Task<TableResult> Retrieve<T>(string tableReference, string partitionKey, string rowKey) where T : ITableEntity
        {
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference(tableReference);
            TableOperation retrieveOperation = TableOperation.Retrieve<T>(partitionKey, rowKey);
            TableResult retrievedResult = await table.ExecuteAsync(retrieveOperation);
            return retrievedResult;
        }
