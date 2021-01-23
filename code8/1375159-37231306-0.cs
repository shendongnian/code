    public class StreamReader
    {
        private string _filePath;
        public StreamReader(string filePath)
        {
            _filePath = Path.IsPathRooted(filePath)
                ? filePath
                : Path.Combine(System.Configuration.ConfigurationManager.AppSettings["CsvRootPath"], filePath);
        }
    }
