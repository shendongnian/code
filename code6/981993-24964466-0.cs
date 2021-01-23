    [StructLayout( LayoutKind.Sequential, Pack = 1 )]
    public struct Data
    {            
        public byte Dummy;
        [MarshalAs( UnmanagedType.ByValArray, SizeConst = 4,
                    ArraySubType = UnmanagedType.U1 )]
        public byte[] a2;
    }
