    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    struct CryptKeyProviderInformation
    {
        public String pwszContainerName;
        public String pwszProvName;
        public Int32 dwProvType;
        public Int32 dwFlags;
        public Int32 cProvParam;
        public IntPtr rgProvParam;
        public Int32 dwKeySpec;
    }
