        [DllImport("Iphlpapi.dll", CharSet = CharSet.Auto)]
    public static extern int GetInterfaceInfo(Byte[] PIfTableBuffer, ref int size);
    
    
     [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    
    public struct IP_ADAPTER_INDEX_MAP
    {
        public int Index;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = PInvokes.MAX_ADAPTER_NAME)]
        public String Name;
    }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct IP_INTERFACE_INFO
        {
            public int NumAdapters;
            public IP_ADAPTER_INDEX_MAP[] Adapter;
    
            public static IP_INTERFACE_INFO FromByteArray(Byte[] buffer)
            {
            unsafe
            {
                IP_INTERFACE_INFO rv = new IP_INTERFACE_INFO();
                int iNumAdapters = 0;
                Marshal.Copy(buffer, 0, new IntPtr(&iNumAdapters), 4);
                IP_ADAPTER_INDEX_MAP[] adapters = new IP_ADAPTER_INDEX_MAP[iNumAdapters];
                rv.NumAdapters = iNumAdapters;
                rv.Adapter = new IP_ADAPTER_INDEX_MAP[iNumAdapters];
                int offset = sizeof(int);
                for (int i = 0; i < iNumAdapters; i++)
                {
                IP_ADAPTER_INDEX_MAP map = new IP_ADAPTER_INDEX_MAP();
                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(map));
                Marshal.StructureToPtr(map, ptr, false);
                Marshal.Copy(buffer, offset, ptr, Marshal.SizeOf(map));
                map = (IP_ADAPTER_INDEX_MAP)Marshal.PtrToStructure(ptr, typeof(IP_ADAPTER_INDEX_MAP));
                Marshal.FreeHGlobal(ptr);
                rv.Adapter[i] = map;
                offset += Marshal.SizeOf(map);
                }
                return rv;
             }
            }
        }
    
        internal class PInvokes
        {
            public const int MAX_ADAPTER_NAME = 128;
    
            public const int ERROR_INSUFFICIENT_BUFFER = 122;
            public const int ERROR_SUCCESS = 0;
    
            [DllImport("Iphlpapi.dll", CharSet = CharSet.Auto)]
            public static extern int GetInterfaceInfo(Byte[] PIfTableBuffer, ref int size);
    
            [DllImport("Iphlpapi.dll", CharSet = CharSet.Auto)]
            public static extern int IpReleaseAddress(ref IP_ADAPTER_INDEX_MAP AdapterInfo);
        }
    
        public class Iphlpapi
        {
            public static IP_INTERFACE_INFO GetInterfaceInfo()
            {
            int size = 0;
            int r = PInvokes.GetInterfaceInfo(null, ref size);
            Byte[] buffer = new Byte[size];
            r = PInvokes.GetInterfaceInfo(buffer, ref size);
            if (r != PInvokes.ERROR_SUCCESS)
                throw new Exception("GetInterfaceInfo returned an error.");
            IP_INTERFACE_INFO info = IP_INTERFACE_INFO.FromByteArray(buffer);
            return info;
            }
    
            public static bool IpReleaseAddress(IP_ADAPTER_INDEX_MAP adapter)
            {
            if (PInvokes.IpReleaseAddress(ref adapter) == PInvokes.ERROR_SUCCESS)
                return true;
            else
                return false;
            }
    
            public static void IpReleaseAllAddresses()
            {
            IP_INTERFACE_INFO info = GetInterfaceInfo();
            for (int i = 0; i < info.NumAdapters; i++)
                IpReleaseAddress(info.Adapter[i]);
            }
        }
