    [StructLayout(LayoutKind.Sequential,Pack =1), Serializable]
        struct Message
        {
            public int cmd;
            public int state;
            public int step;
            public int dataLength;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string ip_segment;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
            public byte[] data;
        }
