    public class Service1 : ISimulatorService
    {
        private ObjectCache _cache = MemoryCache.Default;
        private CacheItemPolicy policy = new CacheItemPolicy();
    
        public void SetSerialNumber(int value)
        {
            _cache.Set("serial", value, policy);
        }
    
        public int GetSerialNumber()
        {
            (int)_chache["serial"];
        }
     }
