    public static class Utils
    {
        public IFileSystem FileSystem { get; set; }
        
        public static void SetUp(IFileSystem fs)
        {
            FileSystem = fs;
        }
    }
