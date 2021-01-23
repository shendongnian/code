    protected SomeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            if (info != null)
            {
                // Some work...
            }
        }
