    void outToLog(string output)
    {
        if (String.IsNullOrEmpty(logRichTextBox.Text)) 
            logRichTextBox.AppendText(output);
        else
            logRichTextBox.AppendText(Environment.NewLine + output);
    
        logRichTextBox.ScrollToCaret();
    }
