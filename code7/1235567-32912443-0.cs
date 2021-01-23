    public struct DOT11_SSID
    {
        public UInt32 uSSIDLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DOT11_SSID_MAX_LENGTH)]
        public byte[] ucSSID;
    }
