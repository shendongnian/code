		/// <summary>
		/// Compressing the data
		/// </summary>
		[Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true, IsPrecise = true, DataAccess = DataAccessKind.None)]
		public static SqlBytes BinaryCompress(SqlBytes input)
		{
			if (input.IsNull) return SqlBytes.Null;
			using (MemoryStream result = new MemoryStream())
			{
				using (DeflateStream deflateStream =
				       new DeflateStream(result, CompressionMode.Compress, true))
				{
					deflateStream.Write(input.Buffer, 0, input.Buffer.Length);
					deflateStream.Flush();
					deflateStream.Close();
				}
				return new SqlBytes(result.ToArray());
			}
		}
		/// <summary>
		/// Decompressing the data
		/// </summary>
		[Microsoft.SqlServer.Server.SqlFunction(IsDeterministic = true, IsPrecise = true, DataAccess = DataAccessKind.None)]
		public static SqlBytes BinaryDecompress(SqlBytes input)
		{
			if (input.IsNull) return SqlBytes.Null;
			int batchSize = 32768;
			byte[] buf = new byte[batchSize];
			using (MemoryStream result = new MemoryStream())
			{
				using (DeflateStream deflateStream =
				       new DeflateStream(input.Stream, CompressionMode.Decompress, true))
				{
					int bytesRead;
					while ((bytesRead = deflateStream.Read(buf, 0, batchSize)) > 0)
						result.Write(buf, 0, bytesRead);
				}
				return new SqlBytes(result.ToArray());
			}
		}
		
		
		public static string GetHexaStringFromBinary (byte[] data)
	    {
	    	string hexData = "0x";
	    	for (int i = 0; i < data.Length; i++) {
                hexData = string.Concat (hexData, data[i].ToString("X2"));
	    	}
			return hexData;
		}
		
		public static byte[] GetBinaryFromHexaString (string hexa)
		{
		    byte[] data = null;
		    List<byte> bList = new List<byte>();
		    try {
		        for (int i = 2; i < hexa.Length - 1; i+=2) {
		            string hStr = hexa.Substring(i, 2);
		            byte b = byte.Parse(hStr, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
		            bList.Add (b);
		        }
		        data = bList.ToArray();
		    }
		    catch {}
		    return data;
		}
