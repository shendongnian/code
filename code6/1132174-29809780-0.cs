    /*  
    This method reads text from a file line by line, splitting each string into segments by a white space delimiter. 
    If the first word is the same as the provided search term, the line is appended to a list of strings which is
    then returned as the result. */
    public List<string> GetLinesWithWord(string word, string filename)
    {
    	List<string> result = new List<string>();
    	
    	using (StreamReader reader = new StreamReader(@"C:\sample.txt"))
    	{
    		string line = string.empty;
    		while ((line = reader.ReadLine()) != null)
    		{
    			var parts = line.Split(' ');
    			
    			if (parts[0].ToLower().Trim() == word.ToLower().Trim())
    			{
    				result.Add(line);
    			}
    		}
    	}
    	
    	return result;
    }
