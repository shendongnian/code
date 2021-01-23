    public interface Ilibrary
    {
        string GetName();
    }
    public class Library : Ilibrary
    {
        private ILog _log;
        public Library(ILog log)
        {
            _log = log;
        }
        public string GetName()
        {
            _log.Debug("log message");
            return "test";
        }
    }
    
