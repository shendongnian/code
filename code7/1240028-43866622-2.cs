    public static class IpAddressExtension {
        public static bool IsIPAddress(this string ipAddress) {
            System.Net.IPAddress address = null;
            return System.Net.IPAddress.TryParse(ipAddress, out address);
        }
    }
