    public List<byte> EncodeNumbers(List<long> input)
	{
		List<byte> bytes = new List<byte>();
		int bytes_i = 0;
		for (int a = 0; a < input.Count; a++)
		{
			int buffer_i = 65;
			byte[] buffer = new byte[buffer_i];
			while (input[a] > 0)
			{
				buffer[--buffer_i] = (byte)(input[a] %15);
				input[a] /= 15;
			}
			for (int b = 0; b < 65 -buffer_i; b++)
			{
				if (bytes_i %2 == 0)
				{
					bytes.Add((byte)(buffer[b +buffer_i] << 4));
					bytes_i++;
				}else{
					bytes[bytes_i++ /2] += buffer[b +buffer_i];
				}
			}
			if (a +1 != input.Count)
			{
				if (bytes_i %2 == 0)
				{
					bytes.Add(0xF << 4);
					bytes_i++;
				}else{
					bytes[bytes_i++ /2] += 0xF;
				}
			}
			else if (bytes_i %2 != 0)
			{
				bytes[bytes_i++ /2] += 0xF;
			}
		}
		return bytes;
	}
