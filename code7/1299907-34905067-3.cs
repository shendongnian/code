    using System;
    using System.Runtime.Serialization;
    [Serializable]
    public class ConfigurationValueMissingException : Exception
    {
        public ConfigurationValueMissingException()
        {
        }
        public ConfigurationValueMissingException(string message)
            : base(message)
        {
        }
        public ConfigurationValueMissingException(string message, Exception inner)
            : base(message, inner)
        {
        }
        protected ConfigurationValueMissingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
