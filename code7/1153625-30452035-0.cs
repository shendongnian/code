    public class LogMessage
    {
        public static FirstMessage First { get { return FirstMessage.Instance; } }
        public static SecondMessage Second { get { return SecondMessage.Instance; } }
        // Prevent instantiation outside this class's program text.
        private LogMessage() {}
        protected void LogImpl(string code, params string[] parameters)
        {
            ...
        }
        // You may have some common public methods here, potentially...
        public sealed class FirstMessage : LogMessage
        {
            internal readonly static FirstMessage Instance = new FirstMessage();
            private FirstMessage() {}
            public void WriteLog(string userName, string logSource, int targetLocation)
            {
                // Call to LogImpl here
            }
        }
        // Ditto for SecondMessage
    }
