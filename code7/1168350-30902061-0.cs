    string oldText = richTextBox.Text;
    
    for (int i = 0; i < X; i++)
    {
        // process stuff
        richTextBox.Text = oldText + Environment.NewLine + "Processed: " + i + " Records.";
    }
