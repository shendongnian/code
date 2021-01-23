    interface ILogger
    {
        void Log(string msg);
        event Action<string> LogMessages;
    }
    
    class ConsoleLogger : ILogger
    {
        public event Action<string> LogMessages = (msg) => { };
    
        public void Log(string msg)
        {
            Console.WriteLine(msg);
            LogMessages(msg);
        }
    }
