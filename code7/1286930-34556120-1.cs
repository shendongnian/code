    internal byte[] ByteReader(int length)
    {
		using (NetworkStream stream = client.GetStream())
		{
			byte[] data = new byte[length];
			using (MemoryStream ms = new MemoryStream())
			{
				int numBytesRead;
				int numBytesReadsofar = 0;
				while (true)
				{
					numBytesRead = stream.Read(data, 0, data.Length);
					numBytesReadsofar += numBytesRead;
					ms.Write(data, 0, numBytesRead);
					if (numBytesReadsofar == length)
					{
						break;
					}
				}
				return ms.ToArray();
			}
		}
    }
