    class Message
    {
        private readonly Stream _stream;
        private byte[] _inMemoryBytes;
        public Message(Stream stream)
        {
            _stream = stream;
        }
        public IEnumerable<byte> Header
        {
            get
            {
                if (_inMemoryBytes.Length >= 20)
                    return _inMemoryBytes.Take(20);
                _stream.Read(_inMemoryBytes, 0, 20);
                return _inMemoryBytes.Take(20);
            }
        }
        public IEnumerable<byte> FullMessage
        {
            get
            {
                // Read and return the whole message. You might want amend to data already read.
            }
        }
    }
