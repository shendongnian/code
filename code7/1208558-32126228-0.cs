    internal class Definition
    {
        public string Name { get; set; }
        public DataStoreTypes SourceDataStoreType { get; set; }
        public DataStoreTypes DestinationDataStoreType { get; set; }
        public IDataStore SourceDataStore { get; set; }
        public IDataStore DestinationDataStore { get; set; }
        public Definition()
        {
            var container = YourIOCContainerHere.Instance;
            SourceDataStore = container.Resolve<IDataStore>();
            DestinationDataStore = container.Resolve<IDataStore>();
            //Or, without using IOC/DI
            SourceDataStore = new SqlDataStore();
            DestinationDataStore = new SqlDataStore();
        }
    }
