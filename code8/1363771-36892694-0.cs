    public static string replaceHipHip(this string text, string old, string hip, string hop)
	{
		var result = new StringBuilder();
		bool b = true;
		int i = 0;
		while(i>=0)
		{
			int j = text.IndexOf(old, i);
			if (j == -1)
			{
				result.Append(text.Substring(i));
				break;
			}
			else
			{
				result.Append(text.Substring(i, j - i));
				if (b)
					result.Append(hip);
				else
					result.Append(hop);
				b ^= true;
				i = j+old.Length;
			}
		}
		return result.ToString();
	}
