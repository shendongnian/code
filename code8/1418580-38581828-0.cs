    public static class ULongExtensions
    {
        public static ulong ToKbytes(this ulong memory)
        {
            return memory / 1000;
        }
        public static ulong ToMByptes(this ulong memory)
        {
            return memory.ToKbytes() / 1000;
        }
    }
