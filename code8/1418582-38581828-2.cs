    public static class ULongExtensions
    {
        public static ulong ToKBytes(this ulong memory)
        {
            return memory / (double)1024;
        }
        public static ulong ToMByptes(this ulong memory)
        {
            return memory.ToKbytes() / (double)1024;
        }
    }
