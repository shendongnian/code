    [StructLayout(LayoutKind.Sequential)]
    struct Int64ByteArr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] bytes;
        public UInt64 u64
        {
            get { return BitConverter.ToUInt64(bytes, 0); }
            set { bytes = BitConverter.GetBytes(value); }
        }
        public Int64 s64
        {
            get { return BitConverter.ToInt64(bytes, 0); }
            set { bytes = BitConverter.GetBytes(value); }
        }
    }
