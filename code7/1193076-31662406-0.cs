    public class CountingStream : Stream
    {
        private Stream _stream;
        private long _totalBytesRead;
        private long _totalBytesWritten;
        public CountingStream(Stream stream)
        {
            _stream = stream;
            _totalBytesRead = 0;
            _totalBytesWritten = 0;
        }
        public long TotalBytesRead { get { return _totalBytesRead; } }
        public long TotalBytesWritten { get { return _totalBytesWritten; } }
        public override void Flush()
        {
            _stream.Flush();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _stream.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = _stream.Read(buffer, offset, count);
            _totalBytesRead += bytesRead;
            return bytesRead;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _totalBytesWritten += count;
            _stream.Write(buffer, offset, count);
        }
        public override bool CanRead
        {
            get { return _stream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _stream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return _stream.CanWrite; }
        }
        public override long Length
        {
            get { return _stream.Length; }
        }
        public override long Position
        {
            get { return _stream.Position; }
            set { _stream.Position = value; }
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing)
                    return;
                if (_stream == null)
                    return;
                try
                {
                    Flush();
                }
                finally
                {
                    _stream.Close();
                }
            }
            finally
            {
                _stream = null;
                base.Dispose(disposing);
            }
        }
    }
