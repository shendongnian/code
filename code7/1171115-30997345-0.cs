    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1), Serializable]
    internal struct TempStruct
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string iuTest;
        public TempStruct(Guid IuTest)
            : this()
        {
            iuTest = IuTest.ToString("D");
        }
    }
    [DllImport("NativeLibrary", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
    public static extern void TempStructMethod(IntPtr ptr);
