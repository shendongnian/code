    /*  
    This method reads text from a file line by line, splitting each string into segments by a white space delimiter. 
    If the first word is the same as the provided search term, the line is appended to a list of strings which is
    then returned as the result. */
    public List<string> GetLinesWithWord(string word, string filename)
    {
    	List<string> result = new List<string>(); // A list of strings where the first word of each is the provided search term.
    	
    	// Create a stream reader object to read a text file.
    	using (StreamReader reader = new StreamReader(@"C:\sample.txt"))
    	{
    		string line = string.empty; // Contains a single line returned by the stream reader object.
    		
    		// While there are lines in the file, read a line into the line variable.
    		while ((line = reader.ReadLine()) != null)
    		{
    			// Split the line into parts by a white space delimiter.
    			var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    			
    			// Get only the first word element of the line, trim off any additional white space
    			// and convert the it to lowercase. Compare the word element to the search term provided.
    			// If they are the same, add the line to the results list.
    			if (parts[0].ToLower().Trim() == word.ToLower().Trim())
    			{
    				result.Add(line);
    			}
    		}
    	}
    	
    	return result;
    }
