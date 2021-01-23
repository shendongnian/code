        public static byte[] ToMACBytes(this string mac) {
            if (mac.IndexOf(':') > 0)
                mac = mac.Replace(':', '-');
            return PhysicalAddress.Parse(mac).GetAddressBytes();
        }
