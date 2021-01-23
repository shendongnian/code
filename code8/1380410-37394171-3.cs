    public class DisposeBlocker : Stream
    {
        private readonly Stream _source;
        public DisposeBlocker(Stream source)
        {
            _source = source;
        }
        protected override void Dispose(bool disposing)
        {
            //Do nothing
        }
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return _source.CopyToAsync(destination, bufferSize, cancellationToken);
        }
        public override void Close()
        {
            _source.Close();
        }
        public override void Flush()
        {
            _source.Flush();
        }
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return _source.FlushAsync(cancellationToken);
        }
        protected override WaitHandle CreateWaitHandle()
        {
            //Obsolete method, Reference Source states just return the following.
            return new ManualResetEvent(false);
        }
        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _source.BeginRead(buffer, offset, count, callback, state);
        }
        public override int EndRead(IAsyncResult asyncResult)
        {
            return _source.EndRead(asyncResult);
        }
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return _source.ReadAsync(buffer, offset, count, cancellationToken);
        }
        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            return _source.BeginWrite(buffer, offset, count, callback, state);
        }
        public override void EndWrite(IAsyncResult asyncResult)
        {
            _source.EndWrite(asyncResult);
        }
        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return _source.WriteAsync(buffer, offset, count, cancellationToken);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return _source.Seek(offset, origin);
        }
        public override void SetLength(long value)
        {
             _source.SetLength(value);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return _source.Read(buffer, offset, count);
        }
        public override int ReadByte()
        {
            return _source.ReadByte();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _source.Write(buffer, offset, count);
        }
        public override void WriteByte(byte value)
        {
            _source.WriteByte(value);
        }
        protected override void ObjectInvariant()
        {
            //Obsolete method, nothing to override.
        }
        public override bool CanRead
        {
            get { return _source.CanRead; }
        }
        public override bool CanSeek
        {
            get { return _source.CanSeek; }
        }
        public override bool CanTimeout
        {
            get { return _source.CanTimeout; }
        }
        public override bool CanWrite
        {
            get { return _source.CanWrite; }
        }
        public override long Length
        {
            get { return _source.Length; }
        }
        public override long Position
        {
            get { return _source.Position; }
            set { _source.Position = value; }
        }
        public override int ReadTimeout
        {
            get { return _source.ReadTimeout; }
            set { _source.ReadTimeout = value; }
        }
        public override int WriteTimeout
        {
            get { return _source.WriteTimeout; }
            set { _source.WriteTimeout = value; }
        }
        public override object InitializeLifetimeService()
        {
            return _source.InitializeLifetimeService();
        }
        public override ObjRef CreateObjRef(Type requestedType)
        {
            return _source.CreateObjRef(requestedType);
        }
        public override string ToString()
        {
            return _source.ToString();
        }
        public override bool Equals(object obj)
        {
            return _source.Equals(obj);
        }
        public override int GetHashCode()
        {
            return _source.GetHashCode();
        }
    }
