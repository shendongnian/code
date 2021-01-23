        public static class UriExtension {
            public static bool IsIPAddress(this string input) {
                var hostNameType = Uri.CheckHostName(input);
                
                return hostNameType == UriHostNameType.IPv4 || hostNameType == UriHostNameType.IPv6;
            }
        }
