    class ProcInfo
    {
        public FileInfo FileProc { get; set; }
        public int Handle { get; set; }
        public List<ModInfo> Modules { get; set; }
    
        public ProcInfo()
        {
            Modules = new List<ModInfo>();
        }
    }
    
    class ModInfo
    {
        public FileInfo FileMod { get; set; }
    }
