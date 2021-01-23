	public class DualStream : Stream
	{
		private readonly Stream _first;
		private readonly Stream _second;
		public DualStream(Stream first, Stream second)
		{
			_first = first;
			_second = second;
		}
		public override bool CanRead => true;
		public override bool CanSeek => true;
		public override bool CanWrite => false;
		public override long Length => _first.Length + _second.Length;
		public override long Position
		{
			get { return _first.Position + _second.Position; }
			set { Seek(value, SeekOrigin.Begin); }
		}
		public override void Flush() { throw new NotImplementedException(); }
		public override int Read(byte[] buffer, int offset, int count)
		{
			var bytesRead = _first.Read(buffer, offset, count);
			if (bytesRead == count) return bytesRead;
			return bytesRead + _second.Read(buffer, offset + bytesRead, count - bytesRead);
		}
		public override long Seek(long offset, SeekOrigin origin)
		{
			// To simplify, let's assume seek always works as if over one big MemoryStream
			long targetPosition;
			
			switch (origin)
			{
				case SeekOrigin.Begin: targetPosition = offset; break;
				case SeekOrigin.Current: targetPosition = Position + offset; break;
				case SeekOrigin.End: targetPosition = Length - offset; break;
				default: throw new NotSupportedException();
			}
			targetPosition = Math.Max(0, Math.Min(Length, targetPosition));
			var firstPosition = Math.Min(_first.Length, targetPosition);
			_first.Position = firstPosition;
			_second.Position = Math.Max(0, targetPosition - firstPosition);
			return Position;
		}
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_first.Dispose();
				_second.Dispose();
			}
			base.Dispose(disposing);
		}
		public override void SetLength(long value) 
          { throw new NotImplementedException(); }
		public override void Write(byte[] buffer, int offset, int count) 
          { throw new NotImplementedException(); }
    }
