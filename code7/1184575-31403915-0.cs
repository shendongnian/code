    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Pack = 4)]
    public struct RASENTRY
    {
        public int       dwSize;
        public int       dwfOptions;
        public int       dwCountryID;
        public int       dwCountryCode;
    // etc.
