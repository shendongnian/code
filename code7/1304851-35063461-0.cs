      public class LogException : Exception
        {
    
            private readonly ErrorCode errorCode;
    
            /// <summary>Gets the service name which related to this exception.</summary>
            public ErrorCode ErrorCode
            {
                get { return errorCode; }
            }
    
            public LogException()
            {
            }
    
            public LogException(string message)
                : base(message)
            {
            }
    
            public LogException(string message, Exception inner)
                : base(message, inner)
            {
            }
    
            public LogException(string message, Exception inner, ErrorCode errorCode)
                : base(message, inner)
            {
                this.errorCode = errorCode;
            }
        }
    
        public class CustomLogErrorHandler : IErrorHandler
        {
            public string message { get;private set; }
            public Exception Exception { get; private set; }
            public ErrorCode ErrorCode { get; private set; }
    
            #region IErrorHandler Members
            public void Error(string message)
            {
                this.message = message;
            }
            public void Error(string message, Exception e)
            {
                this.message = message;
                this.Exception = e;
            }
            public void Error(string message, Exception e, ErrorCode errorCode)
            {
                this.message = message;
                this.Exception = e;
                this.ErrorCode = errorCode;
            }
            #endregion
        }
