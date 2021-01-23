    [StructLayout(LayoutKind.Sequential)]
        public struct information
        {
            public int version;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst=16)]
            public string serial_number;
            public ushort exp_date;
        };
