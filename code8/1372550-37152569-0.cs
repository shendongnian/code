    public class Service1 : ISimulatorService
    {
        private ObjectCache _cache = MemoryCache.Default;        
    
        public void SetSerialNumber(int value)
        {
            _cache["serial"] = value;
        }
    
        public int GetSerialNumber()
        {
            (int)_chache["serial"];
        }
     }
