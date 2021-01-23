    class ExceptionWrapper : Exception
    {
        private readonly string _trace;
        private readonly string _message;
        private readonly string _toString;
        private readonly object _stackTrace;
        public ExceptionWrapper(Exception e)
        {
            _trace = e.StackTrace;
            _message = e.Message + ", wrapped";
            _toString = e.ToString();
            _stackTrace = typeof(Exception).GetField("_stackTrace",
                BindingFlags.NonPublic | BindingFlags.Instance).GetValue(e);
        }
        public override string StackTrace { get { return _trace; } }
        public override string Message
        {
            get
            {
                typeof(Exception)
                    .GetField("_stackTrace", BindingFlags.NonPublic | BindingFlags.Instance)
                    .SetValue(this, _stackTrace);
                return _message;
            }
        }
        public override string ToString() { return _toString; }
    }
