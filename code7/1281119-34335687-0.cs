    using System.Net.NetworkInformation;
    using System.Management;
    class NetworkManager
    {
        public static NetworkInterface GetNetworkInterface(string sName)
        {
            NetworkInterface NetInterface = null;
            // Precondition
            if (sName == "") return null;
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                if (ni.Name == sName)
                {
                    NetInterface = ni;
                    break;
                }
            }
            return NetInterface;
        }
