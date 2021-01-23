    class Program
    {
        static void Main()
        {
            bool x = true;
            bool y = ByteToBoolean(2); // PURE EVIL
            Console.WriteLine(x); // True
            Console.WriteLine(y); // True
            Console.WriteLine(x & y); // False (!) because 1 & 2 == 0
        }
        static bool ByteToBoolean(byte value)
        {
            BooleanAndByte s;
            s.BooleanValue = false;
            s.ByteValue = value;
            return s.BooleanValue;
        }
    }
    [StructLayout(LayoutKind.Explicit)]
    struct BooleanAndByte
    {
        [FieldOffset(0)]
        public bool BooleanValue;
        [FieldOffset(0)]
        public int ByteValue;
    }
