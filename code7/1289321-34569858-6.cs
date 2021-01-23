    interface ILogger
    {
        void Log(string msg);
        event Action<string> LogMessages;
    }
    
    class PublisherLogger : ILogger
    {
        public event Action<string> LogMessages = (msg) => { };
    
        public void Log(string msg)
        {
            Console.WriteLine(msg);
            LogMessages(msg);
        }
    }
