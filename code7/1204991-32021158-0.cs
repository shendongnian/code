            var account = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);
            var tableClient = account.CreateCloudTableClient();
            var table = tableClient.GetTableReference("Address");
            var entity = new DynamicTableEntity("pk", "rk");
            entity.Properties.Add("Attribute1", new EntityProperty("Attribute 1 Value"));
            TableOperation upsertOperation = TableOperation.InsertOrReplace(entity);
            var tableResult = table.Execute(upsertOperation);
            var result = tableResult.Result;
            Console.WriteLine(result.GetType());//Prints Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity
            var deleteOperation = TableOperation.Delete(entity);
            tableResult = table.Execute(deleteOperation);
            result = tableResult.Result;
            Console.WriteLine(result.GetType());//Prints Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity
            var insertOperation = TableOperation.Insert(entity, false);
            tableResult = table.Execute(insertOperation);
            result = tableResult.Result;
            Console.WriteLine(result.GetType());//Prints Microsoft.WindowsAzure.Storage.Table.DynamicTableEntity
