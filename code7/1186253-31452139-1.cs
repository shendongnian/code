    Dictionary<string, string> members = new Dictionary<string, string>();
    //.. initialization of this dictionary
    
    string pathToFile = "";
    
    string tempfile = Path.GetTempFileName();   //create a temp file
    using (var writer = new StreamWriter(tempfile))
    using (var reader = new StreamReader(pathToFile))
    {
    	//if file is not ended
    	while (!reader.EndOfStream)
    	{
    		//get next line
    		string line = reader.ReadLine();
    
    		//write it to the "temp file"
    		writer.WriteLine(line);
    
    		//search in the line, if found, insert your data
    		if (line.Contains("search what you need"))
    		{
    			foreach (var entry in members)
    				writer.WriteLine("[{0} {1}]", entry.Key, entry.Value);
    		}                    
    	}
    }
    
    //overwrite the actual file with temp file
    File.Copy(tempfile, pathToFile, true);
