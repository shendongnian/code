    public List<long> DecodeNumbers(List<byte> input)
	{
		List<long> numbers = new List<long>();
		int buffer_i = 0;
		byte[] buffer = new byte[17]; // max long = 9223372036854775807 = 160E2AD3246366807 (17 chars)
		for (int a = 0; a < input.Count; a++)
		{
			for (int i = 0; i < 2; i++)
			{
				byte value = (byte)((i == 0) ? input[a] >> 4 : input[a] & 0xF);
				if (value != 0xF)
				{
					buffer[buffer_i++] = value;
				}else{
					long number = 0;
					for (int b = 0; b < buffer_i; b++)
					{
						number += buffer[buffer_i -1 -b] *(long)Math.Pow(15, b);
					}
					buffer_i = 0;
					numbers.Add(number);
				}
			}
		}
		if (buffer_i != 0)
		{
			long number = 0;
			for (int b = 0; b < buffer_i; b++)
			{
				number += buffer[buffer_i -1 -b] *(long)Math.Pow(15, b);
			}
			numbers.Add(number);
		}
		return numbers;
	}
