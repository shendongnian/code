	string s = "20150910000549659ABCD000007348summary.pdf";
	s = s.Replace("summary.pdf", String.Empty);
	int firstLetter = 0;
	foreach (char c in s)
	{
		if (Char.IsLetter(c))
		{
			firstLetter = s.IndexOf(c);
			break;
		}
	}
	s = s.Remove(0, firstLetter);
