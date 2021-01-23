    /// <summary>
    /// Stream that acts as a pipe by supporting reading and writing simultaneously from different threads.
    /// Read calls will block until data is available or the CloseWritePort() method has been called.
    /// Read calls consume bytes in the circular buffer immediately so that more space is available for writes into the circular buffer.
    /// Writes do not block; the capacity of the circular buffer will be expanded as needed to write the entire block of data at once.
    /// </summary>
    class CircularBufferPipeStream : Stream
    {
        const int DefaultCapacity = 1024;
        byte[] _buffer;
        bool _writePortClosed = false;
        object _readWriteSyncRoot = new object();
        int _length;
        ManualResetEvent _dataAddedEvent;
        int _start = 0;
        public CircularBufferPipeStream(int initialCapacity = DefaultCapacity)
        {
            _buffer = new byte[initialCapacity];
            _length = 0;
            _dataAddedEvent = new ManualResetEvent(false);
        }
        public void CloseWritePort()
        {
            lock (_readWriteSyncRoot)
            {
                _writePortClosed = true;
                _dataAddedEvent.Set();
            }
        }
        public override bool CanRead { get { return true; } }
        public override bool CanWrite { get { return true; } }
        public override bool CanSeek { get { return false; } }
        public override void Flush() { }
        public override long Length { get { throw new NotImplementedException(); } }
        public override long Position
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
        public override long Seek(long offset, SeekOrigin origin) { throw new NotImplementedException(); }
        public override void SetLength(long value) { throw new NotImplementedException(); }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead = 0;
            while (bytesRead == 0)
            {
                bool waitForData = false;
                lock (_readWriteSyncRoot)
                {
                    if (_length != 0)
                        bytesRead = ReadDirect(buffer, offset, count);
                    else if (_writePortClosed)
                        break;
                    else
                    {
                        _dataAddedEvent.Reset();
                        waitForData = true;
                    }
                }
                if (waitForData)
                    _dataAddedEvent.WaitOne();
            }
            return bytesRead;
        }
        private int ReadDirect(byte[] buffer, int offset, int count)
        {
            int readTailCount = Math.Min(Math.Min(_buffer.Length - _start, count), _length);
            Array.Copy(_buffer, _start, buffer, offset, readTailCount);
            _start += readTailCount;
            _length -= readTailCount;
            if (_start == _buffer.Length)
                _start = 0;
            int readHeadCount = Math.Min(Math.Min(_buffer.Length - _start, count - readTailCount), _length);
            if (readHeadCount > 0)
            {
                Array.Copy(_buffer, _start, buffer, offset + readTailCount, readHeadCount);
                _start += readHeadCount;
                _length -= readHeadCount;
            }
            return readTailCount + readHeadCount;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            lock (_readWriteSyncRoot)
            {
                // expand capacity as needed
                if (count + _length > _buffer.Length)
                {
                    var expandedBuffer = new byte[Math.Max(_buffer.Length * 2, count + _length)];
                    _length = ReadDirect(expandedBuffer, 0, _length);
                    _start = 0;
                    _buffer = expandedBuffer;
                }
                int startWrite = (_start + _length) % _buffer.Length;
                int writeTailCount = Math.Min(_buffer.Length - startWrite, count);
                Array.Copy(buffer, offset, _buffer, startWrite, writeTailCount);
                startWrite += writeTailCount;
                _length += writeTailCount;
                if (startWrite == _buffer.Length)
                    startWrite = 0;
                int writeHeadCount = count - writeTailCount;
                if (writeHeadCount > 0)
                {
                    Array.Copy(buffer, offset + writeTailCount, _buffer, startWrite, writeHeadCount);
                    _length += writeHeadCount;
                }
            }
            _dataAddedEvent.Set();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataAddedEvent != null)
                {
                    _dataAddedEvent.Dispose();
                    _dataAddedEvent = null;
                }
            }
            base.Dispose(disposing);
        }
    }
