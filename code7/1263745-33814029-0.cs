    public class TestClass
    {
        private readonly ILogger m_Logger;
        public TestClass(ILogger logger)
        {
            m_Logger = logger;
        }
        public ILogger Logger
        {
            get { return m_Logger; }
        }
    }
