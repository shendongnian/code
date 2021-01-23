    class FInfo
    {
        public FileInfo Info { get; set; }
        public FInfo (FileInfo fi)    { Info = fi; }
        public override string ToString()
        {
            return Path.GetFileNameWithoutExtension(Info.FullName);
        }
    }
