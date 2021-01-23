    public class StorageRegistry : Registry
    {
        public StorageRegistry()
        {
            ...
            this.For<IDataStoreInstance>().Use(ctx => ctx.GetInstance<DataStoreAbstractFactory>().ConfigureStorage());
            ...
        }
    }
