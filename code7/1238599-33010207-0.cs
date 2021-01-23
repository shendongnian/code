    internal class SNException : Exception
    {
        private State _state;
        public State GetState
        {
            get { return this._state; }
        }
        public SNException()
        {
        }
        public SNException(State state)
        {
            this._state = state;
        }
        public SNException(string message)
            : base(message)
        {
        }
        public SNException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        protected SNException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
