    namespace YourApp.Framework.Logger
    {
        public interface ILogger
        {
            void Error(Exception ex);
            void Info(object msg);
            void Debug(string msg);
            void Error(string msg, Exception ex);
        }
    }
