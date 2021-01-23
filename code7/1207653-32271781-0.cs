    [DataContract]
    public class EncryptKeyNotFoundException : System.Exception
    {
        public EncryptKeyNotFoundException() : base() { }
        public EncryptKeyNotFoundException(string message) : base(message) { }
        public EncryptKeyNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
