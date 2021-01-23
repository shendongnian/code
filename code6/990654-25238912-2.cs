    public class PartialStream : Stream
    {
        private Stream underlying;
     
        private long offset;
     
        private long length;
     
        public PartialStream(Stream underlying, long offset, long length)
        {
            this.underlying = underlying;
            this.offset = offset;
            if (offset + length > underlying.Length) {
                this.length = underlying.Length - offset;
            } else {
                this.length = length;
            }
     
            this.underlying.Seek(offset, SeekOrigin.Begin);
        }
     
        public override bool CanRead { get { return true; } }
     
        public override bool CanSeek { get { return false; } }
     
        public override bool CanWrite { get { return false; } }
     
        public override void Flush()
        {
            throw new NotSupportedException();
        }
     
        public override long Length
        {
            get { return this.length; }
        }
     
        public override long Position
        {
            get
            {
                return this.underlying.Position - offset;
            }
            set
            {
                this.underlying.Position = offset + Math.Min(value,this.length) ;
            }
        }
     
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.Position + offset >= this.length)
                return 0;
     
            if (this.Position + offset + count > this.length) {
                count = (int)(this.length - this.Position - offset);
            }
     
     
            return underlying.Read(buffer, offset, count);
        }
     
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.underlying.Dispose();
        }
     
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }
     
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
     
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
     
    }
