        static void ListAllEntities()
        {
            var storageAccount = new CloudStorageAccount(new StorageCredentials(StorageAccount, StorageAccountKey), true);
            var tableClient = storageAccount.CreateCloudTableClient();
            var table = tableClient.GetTableReference("mytable");
            List<DynamicTableEntity> entities = new List<DynamicTableEntity>();
            TableContinuationToken token = null;
            do
            {
                var result = table.ExecuteQuerySegmented(new TableQuery(), token);
                token = result.ContinuationToken;
                entities.AddRange(result.Results);
            } while (token != null);
            Console.WriteLine("Total Entities Fetched: " + entities.Count);
        }
