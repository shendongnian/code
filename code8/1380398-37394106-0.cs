	public static string Next(string pattern)
	{
		bool carry = true;
		var sb = new List<char>();
		int t;
		for(int i = pattern.Length - 1; i >= 0; i--)
		{
			if (!carry)
			{
				sb.Insert(0, pattern[i]);
				continue;
			}
			if (char.IsDigit(pattern[i]))
			{
				t = int.Parse(pattern[i].ToString()) + 1;
				if (t == 10)
				{
					sb.Insert(0, '0');
					carry = true;
				}
				else
				{
					sb.Insert(0, t.ToString()[0]);
					carry = false;
				}
			}
			else
			{
				t = (int)pattern[i] + 1;
				if (t == 91)
				{
					sb.Insert(0, 'A');
					carry = true;
				}
				else
				{
					sb.Insert(0, Convert.ToChar(t));
					carry = false;
				}
			}
		}
		return new string(sb.ToArray());
	}
