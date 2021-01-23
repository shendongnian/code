    /// <summary>
    /// Stream capturing the data going to another stream
    /// </summary>
    internal class OutputCaptureStream : Stream
    {
        private Stream InnerStream;
        public MemoryStream CapturedData { get; private set; }
    
        public OutputCaptureStream(Stream inner)
        {
            InnerStream = inner;
            CapturedData = new MemoryStream();
        }
    
        public override bool CanRead
        {
            get { return InnerStream.CanRead; }
        }
    
        public override bool CanSeek
        {
            get { return InnerStream.CanSeek; }
        }
    
        public override bool CanWrite
        {
            get { return InnerStream.CanWrite; }
        }
    
        public override void Flush()
        {
            InnerStream.Flush();
        }
    
        public override long Length
        {
            get { return InnerStream.Length; }
        }
    
        public override long Position
        {
            get { return InnerStream.Position; }
            set { CapturedData.Position = InnerStream.Position = value; }
        }
    
        public override int Read(byte[] buffer, int offset, int count)
        {
            return InnerStream.Read(buffer, offset, count);
        }
    
        public override long Seek(long offset, SeekOrigin origin)
        {
            CapturedData.Seek(offset, origin);
            return InnerStream.Seek(offset, origin);
        }
    
        public override void SetLength(long value)
        {
            CapturedData.SetLength(value);
            InnerStream.SetLength(value);
        }
    
        public override void Write(byte[] buffer, int offset, int count)
        {
            CapturedData.Write(buffer, offset, count);
            InnerStream.Write(buffer, offset, count);
        }
    }
