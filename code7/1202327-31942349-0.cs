    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct structTiFuRecord
    {
        public int intDiscipline;
        public int intNumberOfSets;
        public byte strPlayer1IDlen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer1ID;
        public byte strPlayer2IDlen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer2ID;
        public byte strPlayer3IDlen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer3ID;
        public byte strPlayer4IDlen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer4ID;
        public byte strPlayer1Namelen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer1Name;
        public byte strPlayer2Namelen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer2Name;
        public byte strPlayer3Namelen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer3Name;
        public byte strPlayer4Namelen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string strPlayer4Name;
        public int intTournamentProgress;
        public int intTableNumber;
    }
