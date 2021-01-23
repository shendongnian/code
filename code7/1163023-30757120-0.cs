    public class SomeDataReader
    {
        // publicly visible
        public SomeDataReader()
            : this(new SqlExternalStoreReader(...))
        { }
        // internally visible
        internal SomeDataReader(IExternalStoreReader storeReader)
        {
            ExternalStore = storeReader;
        }
        ...
    }
