    [Serializable]
    public abstract OurFrameworkException : Exception
    {
        public int ErrorCode { get; private set; }
        public OurFrameworkException(int errorCode)
        {
            ErrorCode = errorCode;
        }
    }
