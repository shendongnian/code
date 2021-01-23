    [StructLayout(LayoutKind.Sequential, Pack = 1, Size=255, CharSet = CharSet.Ansi)]
    public struct Menu
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string str1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string str2;
    }
    public static unsafe int fnSys(Menu value)
    {
        if (value!=null)
        {
            System.Windows.Forms.MessageBox.Show("msg");
        }
        return 1;
    }
