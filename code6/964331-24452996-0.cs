    interface IMyLog
    {
        void Info(object message);
        void Info(string format, params object[] args);
    }
    interface ILogger1 : IMyLog { }
    interface ILogger2 : IMyLog { }
