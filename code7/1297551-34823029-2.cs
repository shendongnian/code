    internal struct need
    {
        internal need @true
        {
            get { return true; }
        }
    
        public static implicit operator need(bool value)
        {
            // todo: initialize it
            return new need();
        }
    }
