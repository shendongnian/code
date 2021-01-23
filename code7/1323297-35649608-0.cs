    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RestorePointInfo
    {
        public int dwEventType; 	// The type of event
        public int dwRestorePtType; 	// The type of restore point
        public Int64 llSequenceNumber; 	// The sequence number of the restore point
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxDescW + 1)] 
        public string szDescription; 	// The description to be displayed so 
    				//the user can easily identify a restore point
    } 
