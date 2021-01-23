    /// <summary>
    /// All extensions for IPAddress type
    /// </summary>
    public static class IPAddressExtension
    {
        /// <summary>
        /// Determine whether this IP address is part of the range/subnet
        /// </summary>
        /// <param name="range">A range of IPAddresses</param>
        /// <returns></returns>
        public static bool IsInRange(this IPAddress thisIP, IPAddressRange range)
        {
            return range.Contains(thisIP);
        }
        /// <summary>
        /// Determine whether this IP address is part of the range/subnet
        /// </summary>
        /// <param name="range">Can be specified in CIDR/UNI (ex: 192.168.10.0/24) </param>
        /// <returns></returns>
        public static bool IsInRange(this IPAddress thisIP, string rangeIP)
        {
            IPAddressRange range = IPAddressRange.Parse(rangeIP);
            return range.Contains(thisIP);
        }
        /// <summary>
        /// Determine whether this IP address is part of the range/subnet
        /// </summary>
        /// <param name="ipBegin">Beginning IP address of range</param>
        /// <param name="ipEnd">Ending IP address of range</param>
        /// <returns></returns>
        public static bool IsInRange(this IPAddress thisIP, IPAddress ipBegin, IPAddress ipEnd)
        {
            IPAddressRange range = new IPAddressRange(ipBegin, ipEnd);
            return range.Contains(thisIP);
        }
    }
