    private void processLine(string line)
    {
        //You can clear if necessary
        //richTextBox.Document.Blocks.Clear();
    
        //whatever your logic. I'm only taking the first 10 chars
        string trimmed = text.Substring(0,9); 
        richTextBox.Document.Blocks.Add(new Paragraph(new Run(trimmed)));
    }
