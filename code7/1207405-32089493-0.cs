    public struct abc {
        public int a;
        public int b;
    }
    [DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern abc mainfun();
