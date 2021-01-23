	string s = "thequickbrownfoxjumpsoverthelazydog";
	StringBuilder sb = new StringBuilder();
	for (int i = 0; i < s.Length; i++)
	{
		if (i % 2 == 0)
		{
			sb.Append(s[i].ToString().ToUpper());
		}
		else
		{
			sb.Append(s[i].ToString());
		}
	}
	sb.ToString().Dump();
