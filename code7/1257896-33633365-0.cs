    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct ProcessEntry {
        public int Size;
        public int Usage;
        public int ProcessId;
        public IntPtr DefaultHeapId;
        public int ModuleId;
        public int Threads;
        public int ParentProcessID;
        public int Priority;
        public int Flags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string ExeFile;
    }
