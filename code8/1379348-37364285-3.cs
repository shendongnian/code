    public class MockFileWrapper : IFileWrapper
    {
        public string SoureFileName { get; set; }
        public string DestFileName { get; set; }
        public bool Overwrite { get; set; }
        public void Copy(string sourceFileName, string destFileName, bool overwrite)
        {
            SoureFileName = sourceFileName;
            DestFileName = destFileName;
            Overwrite = overwrite;
        }
    }
