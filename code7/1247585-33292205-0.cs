    [StructLayout(LayoutKind.Explicit)]
	unsafe struct GuidBuffer
	{
		[FieldOffset(0)]
		fixed long buffer[2];
	
		[FieldOffset(0)]
		public Guid Guid;
	
		public GuidBuffer(Guid guid)
			: this()
		{
			Guid = guid;
		}
		public void CopyTo(byte[] dest, int offset)
		{
			if (dest.Length - offset < 16)
				throw new ArgumentException("Destination buffer is too small");
	
			fixed (byte* bDestRoot = dest)
			fixed (long* bSrc = buffer)
			{
				byte* bDestOffset = bDestRoot + offset;
				long* bDest = (long*)bDestOffset;
	
				bDest[0] = bSrc[0];
				bDest[1] = bSrc[1];
			}
		}
	}
