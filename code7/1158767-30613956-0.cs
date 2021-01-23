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
        using (StreamReader sr = new StreamReader(text))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                if (line.StartsWith("INT") || line.StartsWith("EXT"))
                {
                    resultList.Add(line);
                }
            }
        }
    
        return resultList;
    }
