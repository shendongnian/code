    public static class HuffmanConsts
    {
        // output format: Header, serialized tree (prefix), DataDelimiter, coded data (logical blocks are 8 byte large, Little Endian)
        public const string Extension = ".huff";
        private static byte[] _header = new byte[] {0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66}; // string {hu|m}ff
        private static byte[] _dataDelimiter = BitConverter.GetBytes(0L); // eight binary zeroes, regardless of endianity
        public byte[] Header { get { return (byte[])_header.Clone(); } }
        public byte[] DataDelimiter { get { return (byte[])_dataDelimiter.Clone(); } }
    }
