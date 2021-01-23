    public class DataStoreAbstractFactory
    {
        public DataStoreAbstractFactory()
        {
            // Dependencies to figure out data storage method can be injected here.
        }
        public IDataStoreInstance ConfigureStorage()
        {
            // This method can be used to return type of storage based on your configuration (ie: online or maintenance)
        }
    }
    public interface IDataStoreInstance
    {
        void Save();
    }
    public class DatabaseStorage : IDataStoreInstance
    {
        public void Save()
        {
            // Implementation details of persisting data in a database
        }
    }
    public class FileStorage : IDataStoreInstance
    {
        public void Save()
        {
            // Implementation details of persisting data in a file system
        }
    }
