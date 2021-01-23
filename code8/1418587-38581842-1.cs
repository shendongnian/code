    public static class MyExtensions
    {
        public static decimal ToKBytes(this ulong value)
        {
            return value / (decimal)1024;
        }
    
        public static decimal ToMBytes(this ulong value)
        {
            return value / ((decimal)1024 * 1024);
        }
    }
