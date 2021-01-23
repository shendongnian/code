    [Flags]
    public enum EventMessageTypes
    {
        None = 0,
        aaa = 1,
        bbb = 2,
        ccc = 4,
        ddd = 8,
        eee = 16,
        fff = 32,
        All = aaa | bbb | ccc | ddd | eee | fff // All Events
    }
    static void Main(string[] args)
    {
        BitArray bitArray = new BitArray(new bool[] { true, true, false, false, false, false, false, false });
        EventMessageTypes b = (EventMessageTypes)ConvertToByte(bitArray);
        Console.WriteLine(b);
        Console.ReadKey();
    }
    private static byte ConvertToByte(BitArray bits) // http://stackoverflow.com/questions/560123/convert-from-bitarray-to-byte
    {
        if (bits.Count != 8)
        {
            throw new ArgumentException("incorrect number of bits");
        }
        byte[] bytes = new byte[1];
        bits.CopyTo(bytes, 0);
        return bytes[0];
    }
