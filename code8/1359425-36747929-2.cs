    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct BIZARRE
    {
        [FieldOffset(0)]
        public int type;
        [FieldOffset(8)]
        public int val;
        [FieldOffset(8)]
        public double val2;
        [FieldOffset(8)]
        public byte* name;
    }
    class Program
    {
        [DllImport("UnionMapping_dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public unsafe static extern void changeBizarre(ref BIZARRE bizarre, int type, byte* name);
        static unsafe void Main(string[] args)
        {
            BIZARRE bizarre;
            byte[] v = Encoding.ASCII.GetBytes("test");
            bizarre.type = 0;
            bizarre.val = 0;
            bizarre.val2 = 0.0;
            fixed (byte* address = v)
            {
                bizarre.name = address;
                changeBizarre(ref bizarre, 3, bizarre.name);
                Console.WriteLine("{0}", bizarre.val);
            }
            Console.ReadKey();
        }
    }
