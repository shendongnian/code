    public class PersistedAlert : Alert, Microsoft.WindowsAzure.Storage.Table.ITableEntity
    {
            public string PartitionKey
            {
                get { return this.StudentId; }
                set { this.StudentId = value; }
            }
    
            public string RowKey
            {
                get { return this.Id; }
                set { this.Id = value; }
            }
    
            public DateTimeOffset Timestamp { get; set; }
    
            public string ETag { get; set; }
    
            public void ReadEntity(IDictionary<string, Microsoft.WindowsAzure.Storage.Table.EntityProperty> properties, Microsoft.WindowsAzure.Storage.OperationContext operationContext)
            {
                Microsoft.WindowsAzure.Storage.Table.TableEntity.ReadUserObject(this, properties, operationContext);
            }
    
            public IDictionary<string, Microsoft.WindowsAzure.Storage.Table.EntityProperty> WriteEntity(Microsoft.WindowsAzure.Storage.OperationContext operationContext)
            {
                return Microsoft.WindowsAzure.Storage.Table.TableEntity.WriteUserObject(this, operationContext);
            }
    }
