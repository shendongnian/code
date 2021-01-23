    void outToLog(string output)
    {
        if(!string.IsNullOrWhiteSpace(logRichTextBox.Text))
        {
            logRichTextBox.AppendText("\r\n" + output);
        }
        else
        {
            logRichTextBox.AppendText(output);
        }
        logRichTextBox.ScrollToCaret();
    }
