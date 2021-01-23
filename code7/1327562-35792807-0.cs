    public static class MemoryDefault
    {
        static MemoryDefault()
        {
             Memory = MemoryCache.Default;
        }
    
        public static MemoryCache Memory { get; private set; }
        //private set for preventing user to change that value
    }
