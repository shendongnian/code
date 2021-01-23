    class FileStreamExt : FileStream
    {
        private string _fileName;
        private FileMode _mode;
        public FileStreamExt Clone()
        {
            return new FileStreamExt(_fileName, _mode); 
        }
        public FileStreamExt(string filename, FileMode mode)
            : base(filename, mode)
        {
            _fileName = filename;
            _mode = mode;
        }
    }
       FileStreamExt fs  =  FileStreamExt(_fileName,FileAccess.Read); 
       FileStreamExt copy = fs.Clone(); 
