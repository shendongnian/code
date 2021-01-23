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
                // lets assume these don't throw, 
                // the guidelines say they shouldn't
                _streamA?.Dispose();
                _streamB?.Dispose();
            }
        }
    }
