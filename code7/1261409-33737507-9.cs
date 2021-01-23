    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    class Data
    {
        public int _int1;
        public int _int2;
        public short _short1;
        public long _long1;
        public static explicit operator Data(byte[] bytes)
        { 
            GCHandle gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var data = (Data)Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), typeof(Data));
            gcHandle.Free();
            return data;
        }
    }
    ...
    var data = (Data)new byte[] {1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 4, 0, 0, 0, 0, 0, 0, 0};
