    public class LogImpl : ILog
    {
        public void WriteLine(string message)
        {
            Log.WriteLine(...);
        }
    }
    
    public class DebugImpl : ILog
    {
        public void WriteLine(string message)
        {
            Debug.WriteLine(...);
        }
    }
