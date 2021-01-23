	TextReader reader = new StreamReader("C:/Temp/BOM.txt");
	TextWriter writer = new StreamWriter("C:/Temp/xBOM.txt");
	while (!string.IsNullOrEmpty(reader.ReadLine())) 
	{
		string s = reader.ReadLine();
		s = s.Insert(12, "-814590");
		writer.WriteLine(s);
	}
	reader.Dispose();
	writer.Close();
	writer.Dispose();
