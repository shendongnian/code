    [StructLayout(LayoutKind.Sequential)]
    public struct ATLOGINRESPONSE
    {
        public ATLoginResponseType loginResponse; // you need to define the ATLoginResponseType enum
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
        public byte[] permissions;
        public ATTIME serverTime;
    }
