    [DllImport("Lib\\RISInterface.dll", CallingConvention = CallingConvention.StdCall,
        CharSet = CharSet.Ansi, EntryPoint = "Open_Study", ExactSpelling = true)]
    static extern internal int OpenStudy(
        string PatientID,
        string AccessionNo,
        [MarshalAs(UnmanagedType.U1)] bool CloseCurrentStudy,
        [MarshalAs(UnmanagedType.U1)] bool AddToWindow,
        int SeriesRows,
        int SeriesCols,
        int PresentationMode,
        [MarshalAs(UnmanagedType.U1)] bool AutoTile,
        [MarshalAs(UnmanagedType.U1)] bool AutoLoad,
        [MarshalAs(UnmanagedType.U1)] bool RemoteExam
    );
