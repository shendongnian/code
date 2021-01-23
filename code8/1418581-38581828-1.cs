    public static class ULongExtensions
    {
        public static ulong ToKBytes(this ulong memory)
        {
            return memory == 0 ? 0 : (memory / (double)1024);
        }
        public static ulong ToMByptes(this ulong memory)
        {
            return memory == 0 ? 0 : (memory.ToKbytes() / (double)1024);
        }
    }
