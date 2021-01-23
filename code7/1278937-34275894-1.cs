    using System.IO;
    namespace Streams
    {
        public class ByteCountingStream: Stream        
        {
            private readonly Stream inner;
            private long totalBytesWritten;
            private long totalBytesRead;
            public ByteCountingStream(Stream inner)
            {
                this.inner = inner;
            }
            public override void Flush()
            {
                inner.Flush();
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new System.NotImplementedException();
            }
            public override void SetLength(long value)
            {
                throw new System.NotImplementedException();
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                int readBytes = inner.Read(buffer, offset, count);
                totalBytesRead += readBytes;
                return readBytes;
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
                inner.Write(buffer, offset, count);
                totalBytesWritten += count;
            }
            public override bool CanRead => true;
            public override bool CanSeek => false;
            public override bool CanWrite => true;
            public override long Length { get; }
            public override long Position { get; set; }
            public long TotalBytesWritten => totalBytesWritten;
            public long TotalBytesRead => totalBytesRead;
        }
    }
