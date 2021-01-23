    interface ILogger
    {
        //void Log(string message);
        Action<string> Log {get; }
    }
