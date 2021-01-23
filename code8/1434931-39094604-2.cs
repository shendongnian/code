    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class Station
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        public string ClusterID;
        public byte Tech_Type;
        [MarshalAs(UnmanagedType.I1)]
        public bool Status;
        [MarshalAs(UnmanagedType.I1)]
        public bool Reject;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 51)]
        public string Rej_Detail;
        public byte Rej_Catagory;
    }
