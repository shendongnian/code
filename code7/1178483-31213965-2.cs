    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class FrameInfo
    {
        public int FrameNumber;
        public double TimeStamp;
        public IntPtr Image; // This is the problem
        public uint Width;
        public uint Height;
        public uint Stride;
    }
    [DllImport("NativeLibrary", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
    public static extern int OnFrame(int pId, FrameInfo fi);
