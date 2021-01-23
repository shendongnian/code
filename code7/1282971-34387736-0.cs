	public static byte[] DecompressZLibRaw(byte[] bCompressed)
	{
		byte[] bHdr = new byte[] { 0x1F, 0x8b, 0x08, 0, 0, 0, 0, 0 };
		
		using (var sOutput = new MemoryStream()) 
		using (var sCompressed = new MemoryStream())
		{
			sCompressed.Write(bHdr, 0, bHdr.Length);
			sCompressed.Write(bCompressed, 0, bCompressed.Length);
			sCompressed.Position = 0;
			using (var decomp = new GZipStream(sCompressed, CompressionMode.Decompress))
			{
				decomp.CopyTo(sOutput);
			}
			return sOutput.ToArray();
		}
	}
