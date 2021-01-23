    public class Cache
    {
        private ConcurrentDictionary<string, Lazy<long>> i;
        public void Init() { /* init i with values from DB */ }
        public Int64 Get(string value)
        {
            return i.GetOrAdd(value, new Lazy<long>(() =>
                CreateDatabaseRecordAndGetId()))
                .Value;
        }
        private long CreateDatabaseRecordAndGetId()
        {
            throw new NotImplementedException();
        }
    }
