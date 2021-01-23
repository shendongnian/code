    public class CustomSeleniumException: Exception
    {
        public CustomSeleniumException()
        {
        }
    
        public CustomSeleniumException(string message)
            : base(message)
        {
        }
    
        public CustomSeleniumException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
