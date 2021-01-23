    class Logger : IDisposeable
    {
        private string _logName;
        private StreamWriter _w;
    
        public Logger(string logName)
        {
            _logName = logName;
    
            _w = File.AppendText(_logName + ".txt"))
            _w.WriteLine("-------------------------------");
            
        }
    
        public void Log(string logMessage)
        {
            _w.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString() + " " + logMessage);
            Console.WriteLine(logMessage);
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
                _w.Dispose();
        }
    }
