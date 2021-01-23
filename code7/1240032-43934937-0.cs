    public static class UriExtension {
        public static bool IsIPAddress(this string input) {
            return Uri.CheckHostName(input) == UriHostNameType.IPv4 || 
    		Uri.CheckHostName(input) == UriHostNameType.IPv6;
        }
    }
