    public struct TIQStudyAutomation
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] PatientID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] AccessionNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] StudyUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] SeriesUID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] InstanceUID;
        [MarshalAs(UnmanagedType.U1)]
        public bool CloseCurrentStudy;
        [MarshalAs(UnmanagedType.U1)]
        public bool AddToWindow;
        public int SeriesRows;
        public int SeriesCols;
        public int PresentationMode;
        [MarshalAs(UnmanagedType.U1)]
        public bool AutoTile;
        [MarshalAs(UnmanagedType.U1)]
        public bool AutoLoad;
        [MarshalAs(UnmanagedType.U1)]
        public bool RemoteExam;
        [MarshalAs(UnmanagedType.U1)]
        public bool LoadFromAllSources;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] ArchiveName;
    }
        [DllImport("Lib\\RISInterface.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "Open_Study1", ExactSpelling = false)]
        static extern internal int OpenStudy1(TIQStudyAutomation automationInfo);
        private byte[] ConvertToDelphiString255(string input)
        {
            var output = new byte[256];
            if(String.IsNullOrEmpty(input))
            {
                return output;
            }
            var ar = Encoding.ASCII.GetBytes(input);
            var length = ar.Length > 255 ? 255 : ar.Length;
            output[0] = (byte)length;
            for(int i=0; i<length; i++)
            {
                output[i+1] = ar[i];
            }
            return output;
        }
