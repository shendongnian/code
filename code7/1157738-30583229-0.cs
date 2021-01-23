    using System.Runtime.InteropServices;
    
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct Data
    {
        [FieldOffset(0)]
        public short serviceVersion;
        [FieldOffset(2)]
        public short statusCode;
        [FieldOffset(4)]
        public int requestId;
        [FieldOffset(0)]
        public ulong Value;
    }
