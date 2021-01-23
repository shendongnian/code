	public bool IsIsomorphic3(string s, string t)
	{
		if (s.Length != t.Length)
		{
			return false;
		}
		int[] firstNumbering = new int[26];
		int[] firstStringOrder = new int[s.Length];
		int firstCounter = 0;
		for (int i = 0; i < s.Length; i++)
		{
			char c = s[i];
			if (firstNumbering[c - 'a'] == 0)
			{
				firstNumbering[c - 'a'] = ++firstCounter;
			}
			firstStringOrder[i] = firstNumbering[c - 'a'];
		}
		int[] secondNumbering = new int[26];
		int[] secondStringOrder = new int[t.Length];
		int secondCounter = 0;
		for (int j = 0; j < t.Length; j++)
		{
			char c = t[j];
			if (secondNumbering[c - 'a'] == 0)
			{
				secondNumbering[c - 'a'] = ++secondCounter;
			}
			secondStringOrder[j] = secondNumbering[c - 'a'];
		}
		return firstStringOrder.SequenceEqual(secondStringOrder); // Comparing values using Linq
	}
