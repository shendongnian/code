	public bool IsIsomorphic(string s, string t)
	{
		if (s.Length != t.Length)
		{
			return false;
		}
		bool result = true;
		var relation = new Dictionary<char, char>();
		for (int i = 0; i < s.Length; i++)
		{
			char sChar = s[i];
			char tChar = t[i];
			char c;
			if (relation.TryGetValue(sChar, out c))
			{
				if (c != tChar)
				{
					result = false;
					break;
				}
			}
			else if (relation.ContainsValue(tChar))
			{
				result = false;
				break;
			}
			else
			{
				relation.Add(sChar, tChar);
			}
		}
		return result;
	}
