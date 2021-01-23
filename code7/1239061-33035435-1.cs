	public struct ReadInfo
	{
		public long Position;
		public int Count;
		public override string ToString() { return "Pos: " + Position + " Count: " + Count; }
	}
	class TrackingMemoryStream : MemoryStream
	{
		public TrackingMemoryStream(byte[] buffer) : base(buffer) { }
		public int TotalReadCount;
		public List<ReadInfo> ReadInfo = new List<ReadInfo>();
		public override int Read(byte[] buffer, int offset, int count)
		{
			var info = new ReadInfo { Position = Position };
			info.Count = base.Read(buffer, offset, count);
			ReadInfo.Add(info);
			TotalReadCount += info.Count;
			return info.Count;
		}
	}
	static Size GetImageSize(byte[] data)
	{
		using (var dataStream = new TrackingMemoryStream(data))
		using (var image = Image.FromStream(dataStream, false, false))
		{
			var size = image.Size;
			return size;
		}
	}
