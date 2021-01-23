    public static class DnsFuncs
    {
        [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern int DnsQuery(
            [MarshalAs(UnmanagedType.VBByRefStr)]ref string pszName,
            QueryTypes wType,
            QueryOptions options,
            int aipServers,
            ref IntPtr ppQueryResults,
            int pReserved);
        [DllImport("dnsapi", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void DnsRecordListFree(
            IntPtr pRecordList, 
            int FreeType);
        private enum QueryOptions
        {
            DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 1,
            DNS_QUERY_BYPASS_CACHE = 8,
            DNS_QUERY_DONT_RESET_TTL_VALUES = 0x100000,
            DNS_QUERY_NO_HOSTS_FILE = 0x40,
            DNS_QUERY_NO_LOCAL_NAME = 0x20,
            DNS_QUERY_NO_NETBT = 0x80,
            DNS_QUERY_NO_RECURSION = 4,
            DNS_QUERY_NO_WIRE_QUERY = 0x10,
            DNS_QUERY_RESERVED = -16777216,
            DNS_QUERY_RETURN_MESSAGE = 0x200,
            DNS_QUERY_STANDARD = 0,
            DNS_QUERY_TREAT_AS_FQDN = 0x1000,
            DNS_QUERY_USE_TCP_ONLY = 2,
            DNS_QUERY_WIRE_ONLY = 0x100
        }
        private enum QueryTypes
        {
            DNS_TYPE_A = 1,
            DNS_TYPE_NS = 2,
            DNS_TYPE_CNAME = 5,
            DNS_TYPE_SOA = 6,
            DNS_TYPE_PTR = 12,
            DNS_TYPE_HINFO = 13,
            DNS_TYPE_MX = 15,
            DNS_TYPE_TXT = 16,
            DNS_TYPE_AAAA = 28
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct DNS_RECORD
        {
            public IntPtr pNext;
            public string pName;
            public short wType;
            public short wDataLength;
            public int flags;
            public int dwTtl;
            public int dwReserved;
            public DnsData DATA;
            public short wPreference;
            public short Pad;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct DnsData
        {
            public DNS_A_DATA A;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct DNS_A_DATA
        {
            public IP4_ADDRESS IpAddress;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct IP4_ADDRESS
        {
            public UInt32 Ip4Addr;
        }
        public static List<string> GetDnsRecords(string domain)
        {
            IntPtr ptr1 = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            DNS_RECORD recDns;
            DNS_A_DATA recA;
            List<string> Results = new List<string>();
            
            int RtnVal = DnsQuery(
                ref domain,
                QueryTypes.DNS_TYPE_A,
                QueryOptions.DNS_QUERY_NO_HOSTS_FILE, 
                0, 
                ref ptr1, 
                0);
            
            if (RtnVal != 0)
            {
                throw new Win32Exception(RtnVal);
            }
            for (ptr2 = ptr1; !ptr2.Equals(IntPtr.Zero); ptr2 = recDns.pNext)
            {
                recDns = (DNS_RECORD)Marshal.PtrToStructure(ptr2, typeof(DNS_RECORD));
                if (recDns.wType == 1)
                {
                    recA = (DNS_A_DATA)recDns.DATA.A;
                    string ip = ReverseIPAddr(recA.IpAddress.Ip4Addr);
                    Results.Add(ip);
                }
            }
            DnsRecordListFree(ptr2, 0);
            return Results;
        }
        private static string ReverseIPAddr(UInt32 longIP)
        {
            IPAddress ip = IPAddress.Parse(longIP.ToString());
            byte[] ipBytes = ip.GetAddressBytes();
            Array.Reverse(ipBytes);
            string ipAddress = new IPAddress(ipBytes).ToString();
            return ipAddress;
        }
    }
