    public class ConnectionErrorException : Exception
    {
        // ... rest of the code
    
        protected ConnectionErrorException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
