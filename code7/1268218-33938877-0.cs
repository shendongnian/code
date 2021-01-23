    public class LoggableStream : Stream
    {
        private Stream _stream;
        private Encoding _textEncoding;
        public LoggableStream(Stream stream, Encoding textEncoding)
        {
            _stream = stream;
            _textEncoding = textEncoding;
        }
        public override bool CanRead
        {
            get
            {
                return _stream.CanRead;
            }
        }
        public override bool CanSeek
        {
            get
            {
                return _stream.CanSeek;
            }
        }
        public override bool CanWrite
        {
            get
            {
                return _stream.CanWrite;
            }
        }
        public override long Length
        {
            get
            {
                return _stream.Length;
            }
        }
        public override long Position
        {
            get
            {
                return _stream.Position;
            }
            set
            {
                _stream.Position = Position;
            }
        }
        public override void Flush()
        {
            _stream.Flush();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            var result = _stream.Read(buffer, offset, count);
            try
            {
                var log = this._textEncoding.GetString(buffer, offset, count);
                Trace.TraceInformation("READ : " + log);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
            return result;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            var result = _stream.Seek(offset, origin);
            return result;
        }
        public override void SetLength(long value)
        {
            _stream.SetLength(value);
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _stream.Write(buffer, offset, count);
            try
            {
                var log = this._textEncoding.GetString(buffer, offset, count);
                Trace.TraceInformation("WRIT : " + log);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }
    }
