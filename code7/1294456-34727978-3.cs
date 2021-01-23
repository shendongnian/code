    public static class HuffmanConsts
    {
       // output format: Header, serialized tree (prefix), DataDelimiter,
       // coded data (logical blocks are 8 byte large, Little Endian)
       public const string Extension = ".huff";
    
       private static readonly IReadOnlyList<byte> _header =
          // string {hu|m}ff
          Array.AsReadOnly(new byte[] {0x7B, 0x68, 0x75, 0x7C, 0x6D, 0x7D, 0x66, 0x66});
       private static readonly IReadOnlyList<byte> _dataDelimiter =
          // eight binary zeroes, regardless of endianity
          Array.AsReadOnly(BitConverter.GetBytes(0x0000000000000000)); 
    
       public static byte[] Header { get { return _header.ToArray(); } }
       public static byte[] DataDelimiter { get { return _dataDelimiter.ToArray(); } }
    }
