    string line;
    using (StreamReader file = new StreamReader("one_two.config.txt"))
    using (StreamWriter newfile = new StreamWriter("log.txt"))
    {
    	while ((line = file.ReadLine()) != null)
    	{
    		newfile.WriteLine(line);
    	}
    }
