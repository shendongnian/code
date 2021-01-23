    public class ChildNullException: Exception
    {
        public ChildNullException() { }
        public ChildNullException(string message)
            : base(message)
        {
        }
    
        public ChildNullException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
