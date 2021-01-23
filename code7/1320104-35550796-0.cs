    [StructLayout(LayoutKind.Sequential)]
    public struct WTSCLIENT
    {
        private const int CLIENTNAME_LENGTH = 20;
        private const int DOMAIN_LENGTH = 17;
        private const int USERNAME_LENGTH = 20;
        private const int MAX_PATH = 260;
        private const int CLIENTADDRESS_LENGTH = 30;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CLIENTNAME_LENGTH + 1)]
        public string ClientName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DOMAIN_LENGTH + 1)]
        public string Domain;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = USERNAME_LENGTH + 1)]
        public string UserName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
        public string WorkDirectory;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
        public string InitialProgram;
        public byte EncryptionLevel;
        public uint ClientAddressFamily;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = CLIENTADDRESS_LENGTH + 1)]
        public ushort[] ClientAddress;
        public ushort HRes;
        public ushort VRes;
        public ushort ColorDepth;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
        public string ClientDirectory;
        public uint ClientBuildNumber;
        public uint ClientHardwareId;
        public ushort ClientProductId;
        public ushort OutBufCountHost;
        public ushort OutBufCountClient;
        public ushort OutBufLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH + 1)]
        public string DeviceId;
    }
