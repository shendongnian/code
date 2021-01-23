	internal static uint CalculateCrc32(string str)
	{
		uint[] crcTable = Crc32.MakeCrcTable();
		uint crc = 0xffffffff;
		for (int i = 0; i < str.Length; i++)
		{
			char c = str[i];
			crc = (crc >> 8) ^ crcTable[(crc ^ c) & 0xFF];
		}
		return ~crc; //(crc ^ (-1)) >> 0;
	}
	internal static uint[] MakeCrcTable()
	{
		uint c;
		uint[] crcTable = new uint[256];
		for (uint n = 0; n < 256; n++)
		{
			c = n;
			for (int k = 0; k < 8; k++)
			{
				var res = c & 1;
				c = (res == 1) ? (0xEDB88320 ^ (c >> 1)) : (c >> 1);
			}
			crcTable[n] = c;
		}
		return crcTable;
	}
