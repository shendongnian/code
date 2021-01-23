    private List<string> CollectLines()
    {
    	TextRange textRange = new TextRange(
    		// TextPointer to the start of content in the RichTextBox.
    		TestRichTextBox.Document.ContentStart,
    		// TextPointer to the end of content in the RichTextBox.
    		TestRichTextBox.Document.ContentEnd);
    
    	// The Text property on a TextRange object returns a string 
    	// representing the plain text content of the TextRange. 
    	var text = textRange.Text;
    
    	List<string> resultList = new List<string>();
    
    	// Collect all line that begin with INT or EXT
    	// Or use .Contains if the line could begin with a tab (\t), spacing or whatever
    	using (StringReader sr = new StringReader(text))
    	{
    		var line = sr.ReadLine();
    		while (line != null)
    		{
    			
    			if (line.StartsWith("INT") || line.StartsWith("EXT"))
    			{
    				resultList.Add(line);
    			}
    			
    			line = sr.ReadLine();
    		}
    	}
    
    	return resultList;
    }
