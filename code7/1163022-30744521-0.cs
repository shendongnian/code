    public class SomeDataReader
    {
        private Dictionary<string, string> store = new Dictionary<string, string>();
        private readonly IExternalStoreReader externalStore;
        public SomeDataReader(IExternalStoreReader externalStore)
        {
            this.externalStore = externalStore;
        }
