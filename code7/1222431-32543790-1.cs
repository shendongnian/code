    [Serializable]
    public OurFrameworkInvalidOperationException : OurFrameworkException
    {
        public OurFrameworkInvalidOperationException(string description)
            : base(1) //for example
        {
            // store the description
        }
    }
