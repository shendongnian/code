    public static async Task<int> GetCountOfEntitiesInPartition(string tableName, string partitionKey)
        {
            CloudTable table = tableClient.GetTableReference(tableName);
            TableQuery<DynamicTableEntity> tableQuery = new TableQuery<DynamicTableEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey)).Select(new string[] { "PartitionKey" });
            EntityResolver<string> resolver = (pk, rk, ts, props, etag) => props.ContainsKey("PartitionKey") ? props["PartitionKey"].StringValue : null;
            List<string> entities = new List<string>();
            TableContinuationToken continuationToken = null;
            do
            {
                TableQuerySegment<string> tableQueryResult =
                    await table.ExecuteQuerySegmentedAsync(tableQuery, resolver, continuationToken);
                continuationToken = tableQueryResult.ContinuationToken;
                entities.AddRange(tableQueryResult.Results);
            } while (continuationToken != null);
            return entities.Count;
        }
