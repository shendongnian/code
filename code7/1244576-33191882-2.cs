    public class ArgumentExceptionMessage : ArgumentException
    {
        private string _message;
        public ArgumentExceptionMessage(string message, string paramName) 
            : base(message, paramName)
        {
            _message = message;
            
        }
        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
