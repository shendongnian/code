    public class LogBlock
    {
        private readonly string[] _logs;
    
        public LogBlock(string[] logs)
        {
            _logs = logs;
        }
    
        public override string ToString()
        {
            var logBlock = new StringBuilder();
            foreach (var log in _logs)
            {
                logBlock.AppendLine(log);
            }
    
            return logBlock.ToString();
        }
    
        public override bool Equals(object obj)
        {
            return obj is LogBlock && Equals((LogBlock)obj);
        }
    
        private bool Equals(LogBlock other)
        {
            return _logs.SequenceEqual(other._logs);
        }
    
        public override int GetHashCode()
        {
            var hashCode = 0;
            foreach (var log in _logs)
            {
                hashCode += log.GetHashCode();
            }
            return hashCode;
        }
    }
