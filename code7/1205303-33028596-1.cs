    [StructLayout(LayoutKind.Explicit)]
    internal struct NMHDR
    {
        [FieldOffset(0)]
        public IntPtr hWndFrom;
        [FieldOffset(8)]
        public IntPtr idFrom;
        [FieldOffset(16)]
        public UInt16 code;
    };
    /// <summary>
    /// Part of the notification messages sent by the common dialogs
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    internal struct OfNotify
    {
        [FieldOffset(0)]
        public NMHDR hdr;
        [FieldOffset(20)]
        public IntPtr ipOfn;
        [FieldOffset(28)]
        public IntPtr ipFile;
    };
