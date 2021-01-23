    [StructLayout(LayoutKind.Sequential, Pack=2)]
    public struct IDTYPE
    {
        public byte f;
        public byte t;
        public IDTYPE_UNION union;
    };  
