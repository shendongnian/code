        public static string GetDirectConnectionName()
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();
            if (icp != null)
            {
                if(icp.NetworkAdapter.IanaInterfaceType == EthernetIanaType)
                {
                    return icp.ProfileName;
                }
            }
            return null;
        }
        public static string GetCurrentNetworkName()
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();
            if (icp != null)
            {
                return icp.ProfileName;
            }
            var resourceLoader = ResourceLoader.GetForCurrentView();
            var msg = resourceLoader.GetString("NoInternetConnection");
            return msg;
        }
        public static string GetCurrentIpv4Address()
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();
            if (icp != null && icp.NetworkAdapter != null && icp.NetworkAdapter.NetworkAdapterId != null)
            {
                var name = icp.ProfileName;
                var hostnames = NetworkInformation.GetHostNames();
                foreach (var hn in hostnames)
                {
                    if (hn.IPInformation != null &&
                        hn.IPInformation.NetworkAdapter != null &&
                        hn.IPInformation.NetworkAdapter.NetworkAdapterId != null &&
                        hn.IPInformation.NetworkAdapter.NetworkAdapterId == icp.NetworkAdapter.NetworkAdapterId &&
                        hn.Type == HostNameType.Ipv4)
                    {
                        return hn.CanonicalName;
                    }
                }
            }
            var resourceLoader = ResourceLoader.GetForCurrentView();
            var msg = resourceLoader.GetString("NoInternetConnection");
            return msg;
        }
