    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Threading.Tasks;
    
    
    namespace MyFunctions
    {
        public class StorageTableOperation<T> where T : ITableEntity
        {       
            internal CloudTable cloudTable;        
    
            public StorageTableOperation(string tableName)
            {
                string connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudTableClient client = storageAccount.CreateCloudTableClient();
                cloudTable = client.GetTableReference(tableName);
            }
            public T GetTableData(string PartitionKey,string RowKey)
            {           
                TableOperation retOp = TableOperation.Retrieve<T>(PartitionKey, RowKey);
                TableResult result = cloudTable.Execute(retOp);
                T tableData = (T)result.Result;
    
               
                return tableData;
            }
    
            public async Task<bool> UpdateTableData(string PartitionKey, string RowKey, T tableData)
            {
                try
                {               
                    TableOperation operation = TableOperation.InsertOrMerge(tableData);
                    TableResult tableResult = await cloudTable.ExecuteAsync(operation);
                    return true;
                }
                catch(Exception ex)
                {
                    return false;
                }
                
            }
            
        }
    }
 
