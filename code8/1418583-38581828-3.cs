    public static class ULongExtensions
    {
        public static ulong ToKBytes(this ulong memory)
        {
            return memory / 1024;
        }
        public static ulong ToMByptes(this ulong memory)
        {
            return memory.ToKbytes() / 1024;
        }
    }
