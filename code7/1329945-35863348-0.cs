	for (;;)
	{
		string s = reader.ReadLine();
		if (s == null)
		{
			continue;
		}
		
		s = s.Insert(12, "-814590");
		writer.WriteLine(s);
	}
