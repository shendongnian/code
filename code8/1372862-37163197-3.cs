    [Singleton(true)]
    public class DataModelListProviderFactory
    {
        private static DataModelListProvider dataListProvider;
        public DataModelListProvider getInstance()
        {
            if (dataListProvider == null)
            {
                dataListProvider = new DataModelListProvider();
               return dataListProvider;
            }
            else
                return dataListProvider;
        }
    }
