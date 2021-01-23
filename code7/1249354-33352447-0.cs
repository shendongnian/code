    class SerializationOutputStream : Stream
    {
        Stream outputStream, writeStream;
        byte[] buffer;
        int bufferedCount;
        long position;
        public SerializationOutputStream(Stream outputStream, int compressTreshold = 8 * 1024)
        {
            writeStream = this.outputStream = outputStream;
            buffer = new byte[compressTreshold];
        }
        public override long Seek(long offset, SeekOrigin origin) { throw new NotSupportedException(); }
        public override void SetLength(long value) { throw new NotSupportedException(); }
        public override int Read(byte[] buffer, int offset, int count) { throw new NotSupportedException(); }
        public override bool CanRead { get { return false; } }
        public override bool CanSeek { get { return false; } }
        public override bool CanWrite { get { return writeStream != null &&  writeStream.CanWrite; } }
        public override long Length { get { throw new NotSupportedException(); } }
        public override long Position { get { return position; } set { throw new NotSupportedException(); } }
        public override void Write(byte[] buffer, int offset, int count)
        {
            if (count <= 0) return;
            var newPosition = position + count;
            if (this.buffer == null)
                writeStream.Write(buffer, offset, count);
            else
            {
                int bufferCount = Math.Min(count, this.buffer.Length - bufferedCount);
                if (bufferCount > 0)
                {
                    Array.Copy(buffer, offset, this.buffer, bufferedCount, bufferCount);
                    bufferedCount += bufferCount;
                }
                int remainingCount = count - bufferCount;
                if (remainingCount > 0)
                {
                    writeStream = new GZipStream(outputStream, CompressionLevel.Optimal);
                    try
                    {
                        writeStream.Write(this.buffer, 0, this.buffer.Length);                            
                        writeStream.Write(buffer, offset + bufferCount, remainingCount);
                    }
                    finally { this.buffer = null; }
                }
            }
            position = newPosition;
        }
        public override void Flush()
        {
            if (buffer == null)
                writeStream.Flush();
            else if (bufferedCount > 0)
            {
                try { outputStream.Write(buffer, 0, bufferedCount); }
                finally { buffer = null; }
            }
        }
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing || writeStream == null) return;
                try { Flush(); }
                finally { writeStream.Close(); }
            }
            finally
            {
                writeStream = outputStream = null;
                buffer = null;
                base.Dispose(disposing);
            }
        }
    }
