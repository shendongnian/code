    public static long[] powof10 = new long[16]
	{
		1,
		10,
		100,
		1000,
		10000,
		100000,
		1000000,
		10000000,
		100000000,
		1000000000,
		10000000000,
		100000000000,
		1000000000000,
		10000000000000,
		100000000000000,
		1000000000000000
	};
	public static decimal ParseDecimal(string input)
	{
		bool negative = false;
		long n = 0;
		int len = input.Length;
		int decimalPosition = len;
		if (len != 0)
		{
			int start = 0;
			if (input[0] == '-')
			{
				negative = true;
				start = 1;
			}
			if (len < 20)
			{
				for (int k = start; k < len; k++)
				{
					char c = input[k];
					if (c == '.')
					{
						decimalPosition = k +1;
					}else{
						n = (n *10) +(int)(c -'0');
					}
				}
				return new decimal((int)n, (int)(n >> 32), 0, negative, (byte)(len -decimalPosition));
			}else{
				if (len > 30)
				{
					len = 30;
				}
				int halflen = len /2;
				for (int k = start; k < halflen; k++)
				{
					char c = input[k];
					if (c == '.')
					{
						decimalPosition = k +1;
					}else{
						n = (n *10) +(int)(c -'0');
					}
				}
				long n2 = 0;
				bool secondhalfdec = false; 
				for (int k = halflen; k < len; k++)
				{
					char c = input[k];
					if (c == '.')
					{
						decimalPosition = k +1;
						secondhalfdec = true;
					}else{
						n2 = (n2 *10) +(int)(c -'0');
					}
				}
				byte decpos = (byte)(len -decimalPosition);
				return new decimal((int)n, (int)(n >> 32), 0, negative, decpos) *powof10[len -(!secondhalfdec ? halflen : halflen +1)] +new decimal((int)n2, (int)(n2 >> 32), 0, negative, decpos);
			}
		}
		return 0;
	}
