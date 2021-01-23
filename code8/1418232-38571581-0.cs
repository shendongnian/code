    public class Logger : IDisposable
    {
        private FileStream fileStream;
        private StreamWriter streamWriter;
        public void Trace(string message)
        {
            streamWriter.WriteLine(message);
        }
        public Logger(string logFilePath)
        {
            fileStream = new FileStream(logFilePath, FileMode.Append);
            streamWriter = new StreamWriter(fileStream);
        }
        public void Dispose()
        {
            streamWriter.Dispose();
            fileStream.Dispose();
        }
    }
