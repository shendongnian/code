    public struct STATUSSTRUCT
    {
        public UInt64 nameLen;
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 4128)]
        public StringBuilder name;
    }
    
    status = new STATUSSTRUCT();
    status.nameLen = 4128;
    status.name = new StringBuilder(4128);
    getStatus(ref status);
