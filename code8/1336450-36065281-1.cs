    public class FileRecord
    {
        public IEnumerable<IDataRecord> DataRecords { get; private set; }
        public IEnumeable<ImageFile> Images { get; private set; }
        public string IndexFileName { get; private set; }
        public string IndexFilePath { get; private set; }
    }
