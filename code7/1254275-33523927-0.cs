    public class LoopbackStream
    {
        public Stream ReaderStream { get; }
        public Stream WriterStream { get;}
        private readonly BlockingCollection<byte[]> _buffer;
        public LoopbackStream()
        {
            _buffer = new BlockingCollection<byte[]>();
            ReaderStream = new ReaderStreamInternal(_buffer);
            WriterStream = new WriterStreamInternal(_buffer);
        }
        private class WriterStreamInternal : Stream
        {
            private readonly BlockingCollection<byte[]> _buffer;
            public WriterStreamInternal(BlockingCollection<byte[]> buffer)
            {
                _buffer = buffer;
                CanRead = false;
                CanWrite = false;
                CanSeek = false;
            }
            public override void Close()
            {
                _buffer.CompleteAdding();
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                var newData = new byte[count];
                Array.Copy(buffer, offset, newData, 0, count);
                _buffer.Add(newData);
            }
            public override void Flush()
            {
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
            public override bool CanRead { get; }
            public override bool CanSeek { get; }
            public override bool CanWrite { get; }
            public override long Length
            {
                get { throw new NotSupportedException(); }
            }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
        }
        private class ReaderStreamInternal : Stream
        {
            private readonly BlockingCollection<byte[]> _buffer;
            private readonly IEnumerator<byte[]> _readerEnumerator;
            private byte[] _currentBuffer;
            private int _currentBufferIndex = 0;
            public ReaderStreamInternal(BlockingCollection<byte[]> buffer)
            {
                _buffer = buffer;
                CanRead = true;
                CanWrite = false;
                CanSeek = false;
                _readerEnumerator = _buffer.GetConsumingEnumerable().GetEnumerator();
            }
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _readerEnumerator.Dispose();
                }
                base.Dispose(disposing);
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                if (_currentBuffer == null)
                {
                    bool read = _readerEnumerator.MoveNext();
                    if (!read)
                        return 0;
                    _currentBuffer = _readerEnumerator.Current;
                }
                var remainingBytes = _currentBuffer.Length - _currentBufferIndex;
                var readBytes = Math.Min(remainingBytes, count);
                Array.Copy(_currentBuffer, _currentBufferIndex, buffer, offset, readBytes);
                _currentBufferIndex += readBytes;
                if (_currentBufferIndex == _currentBuffer.Length)
                    _currentBuffer = null;
                return readBytes;
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }
            public override void Flush()
            {
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }
            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }
            public override bool CanRead { get; }
            public override bool CanSeek { get; }
            public override bool CanWrite { get; }
            public override long Length
            {
                get { throw new NotSupportedException(); }
            }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
        }
    }
