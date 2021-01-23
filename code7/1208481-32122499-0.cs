        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct FT_DEVICE_LIST_INFO_NODE
        {
            public uint Flags;
            public uint Type;
            public uint ID;
            public uint LocId;
            /// char[16]
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string SerialNumber;
            /// char[64]
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string Description;
        }
