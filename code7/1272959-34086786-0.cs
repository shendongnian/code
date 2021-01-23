            var start = "2015-12-04";
            var end = "2015-12-14";
            var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var tableClient = account.CreateCloudTableClient();
            var table = tableClient.GetTableReference("MyTableName");
            var queryExpression = "PartitionKey ge '" + start + "' and PartitionKey le '" + end + "'";
            TableQuery<DynamicTableEntity> query = new TableQuery<DynamicTableEntity>().Where(queryExpression).Take(250);
            TableContinuationToken token = null;
            List<DynamicTableEntity> allEntities = new List<DynamicTableEntity>();
            do
            {
                var queryResult = table.ExecuteQuerySegmented<DynamicTableEntity>(query, token);
                var entities = queryResult.Results.ToList();
                token = queryResult.ContinuationToken;
                allEntities.AddRange(entities);
                Console.WriteLine("Fetched " + allEntities.Count + " entities so far...");
            }
