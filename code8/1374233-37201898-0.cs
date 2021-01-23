    RemoveEntityByRowKey('123456');
    public static void RemoveEntityByRowKey(string myRowKey)
            {
                try
                {
                    CloudTable table = _tableClient.GetTableReference("MyAzureTable"); 
    
       TableQuery<myEntity> query = new TableQuery<myEntity>()
                       .Where(TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.Equal, myRowKey));
    
                    foreach (var item in table.ExecuteQuery(query))
                    {
                        var oper = TableOperation.Delete(item);
                        table.Execute(oper);                    
                    } 
                }
                catch (Exception ex)
                {
                    LogErrorToAzure(ex);
                    throw;
                }
            }
