    public struct DnsAddr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = DNS_ADDR_MAX_SOCKADDR_LENGTH)]
        public byte[] MaxSa[];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public uint[] DnsAddrUserDword;
    }
