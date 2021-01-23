    class Program
    {
        static void Main()
        {
            bool x = true;
            bool y = Int32ToBoolean(2); // PURE EVIL
            Console.WriteLine(x); // True
            Console.WriteLine(y); // True
            Console.WriteLine(x & y); // False (!)
        }
    
        static bool Int32ToBoolean(int value)
        {
            BooleanAndInt32 s;
            s.BooleanValue = false;
            s.Int32Value = value;
            return s.BooleanValue;
        }
    }
    
    [StructLayout(LayoutKind.Explicit)]
    struct BooleanAndInt32
    {
        [FieldOffset(0)]
        public int Int32Value;
    
        [FieldOffset(0)]
        public bool BooleanValue;
    }
