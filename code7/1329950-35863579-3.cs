    while (reader.Peek() >= 0)
    {
    	string s = reader.ReadLine();
        if(string.IsNullOrEmpty(s)) continue;
    	s = s.Insert(0, "-814590");
    	writer.WriteLine(s);
    }
