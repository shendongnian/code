    public sealed class Logger : IDisposable
    {
        private string _logName;
        private StreamWriter _stream;
        public Logger(string logName)
        {
            _logName = logName;
            _stream = File.AppendText(_logName + ".txt");
        }
        public void Log(string logMessage)
        {
            _stream.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " " + logMessage);
        }
        public void Dispose()
        {
            _stream.Dispose();
        }
    }
