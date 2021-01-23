    using SysSurge.Slazure;
    using SysSurge.Slazure.Linq;
    using SysSurge.Slazure.Linq.QueryParser;
    
    namespace TableOperations
    {
        public class LogOperations 
        {
            public static void DeleteOldLogEntities()
            {
                // Get a reference to the table storage, example just uses the development storage
                dynamic storage = new QueryableStorage<DynEntity>("UseDevelopmentStorage=true");
    
                // Get a reference to the table named "LogTable"
                QueryableTable<DynEntity> logTable = storage.LogTable;
                var query = logTable.Where("Timestamp > @0", DateTime.UtcNow.AddDays(-1));
    
                // Delete all returned log entities
                foreach (var entity in query)
                    logTable.Delete(entity.PartitionKey, entity.RowKey);
            }
    	}
    }
