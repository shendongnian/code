    static void Main() {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(new byte[] { 0x73, 0x6e, 0x6f, 0x6f, 0x70, 0, 0, 0 }, 0, sizeof(long));
            ms.Seek(0, SeekOrigin.Begin);
            using (BinaryReader br = new BinaryReader(ms))
            {
                ulong n = br.ReadUInt64BigEndian();
                Console.WriteLine(n == 0x736e6f6f70000000); // prints True
            }
        }
    }
