        public const int upnp_port = 3075;
        private static UPnPNATClass pnp = new UPnPNATClass();
        private static IStaticPortMappingCollection mapc = pnp.StaticPortMappingCollection;
        public static IPAddress local_ip()
        {
            foreach (IPAddress addr in Dns.GetHostEntry(string.Empty).AddressList)
                if (addr.AddressFamily == AddressFamily.InterNetwork)
                    return addr;
            return null;
        }
        public static void upnp_open()
        {
            mapc.Add(upnp_port, "UDP", upnp_port, local_ip().ToString(), true, "P2P Service Name");
        }
        public static void upnp_close()
        {
            mapc.Remove(upnp_port, "UDP");
        }
