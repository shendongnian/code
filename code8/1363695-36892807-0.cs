    [Serializable]
    public sealed class SerializableException : Exception
    {
        public SerializableException()
        {
        }
        public SerializableException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
        public SerializableException(Exception exception)
            : base(exception.Message, exception.InnerException == null ? null : new SerializableException(exception.InnerException))
        {
            _data = exception.Data;
            HelpLink = exception.HelpLink;
            HResult = exception.HResult;
            Source = exception.Source;
            _stackTrace = exception.StackTrace;
        }
        public override IDictionary Data { get { return _data; } }
        public override string StackTrace { get { return _stackTrace; } }
        private readonly IDictionary _data;
        private readonly string _stackTrace;
    }
