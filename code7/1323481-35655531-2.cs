    [StructLayout(LayoutKind.Sequential, Pack=2)]
    public struct IDTYPE
    {
        public byte f;
        public byte t;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=16)]
        public byte[] i;
        ushort i_legacy
        {
            get
            {
                return (ushort)((ushort)i[0] << 8 | (ushort)i[1]);
            }
        }
    };  
