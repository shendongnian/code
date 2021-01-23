    private void assignmentfinder(string brief, string id)
    {
        Regex rgxLines = new Regex(@"^(.*?)[ \t]+([0-9]{2}\/[0-9]{2}\/[0-9]{4})", RegexOptions.Multiline);
        MatchCollection mLines = rgxLines.Matches(brief);
    
        foreach (Match match in mLines)
        {
            richTextBox1.Text += String.Format("Test: {0}{1}Date: {2}{1}{1}", 
                                                match.Groups[1].Value, 
                                                Environment.NewLine, 
                                                match.Groups[2].Value);
        }
    }
