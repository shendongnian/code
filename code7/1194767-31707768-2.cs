    namespace System
    {
        [Obsolete("Fix this")]
        public class NotImplementedException : Exception 
        {
            public NotImplementedException() : base() {}
            public NotImplementedException(string message) : base(message) {}
            public NotImplementedException(string message, Exception innerException) : base(message, innerException) {}
            protected NotImplementedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
        }
    }
