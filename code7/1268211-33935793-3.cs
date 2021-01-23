    class WriteStreamSplitter : Stream
    {
        public WriteStreamSplitter(Stream a, Stream b)
        {
            _streamA = a;
            _streamB = b;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _streamA.Write(buffer, offset, count);
            _streamB.Write(buffer, offset, count);
        }
        public override bool CanRead { get { return false; } }
        // trivial overloads of all other abstract members, 
        // they may throw NotImplemented
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                // Maybe it's best to do nothing here but a StreamWriter 
                // assumes 'ownership' of the wrapped stream, 
                // so if we want to continue that pattern:
                // the guidelines say these shouldn't throw
                _streamA?.Dispose();
                _streamB?.Dispose();
            }
        }
    }
