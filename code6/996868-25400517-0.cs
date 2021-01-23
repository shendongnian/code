    public class FileInfo // Or whatever
    {
        public string Path { get { ... } };
        public uint Index { get { ... } };
        public ExtendedFileInfo ExtendedFileInfo { get { ... } }
    }
    public class ExtendedFileInfo
    {
        public long Size { get { ... } }
        ...
    }
