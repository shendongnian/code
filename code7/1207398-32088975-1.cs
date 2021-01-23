    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;
    }
    [DllImport("example.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern Point mainfun();
