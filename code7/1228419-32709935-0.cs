	using(StreamReader sr = new StreamReader("Filename"))
	{
        
		while (sr.EndOfStream)
		{
            string line = sr.ReadLine();
			if(line.Trim().Length != 0 && line.Trim().Equals("license="))
			{
				//Do whatever you need to do
			}
		}
	}
