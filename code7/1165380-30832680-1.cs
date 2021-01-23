    public interface ILog
    {
        void Log();
    }
    public class NullLog : ILog
    {
        public void Log() { }
    }
