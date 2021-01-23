    private void FormatTextBox(RichTextBox richText, string p, 
                Color textColor, Color highColor)
    {
        string[] lines = richText.Lines;
        richText.Text = "";
        foreach (string line in lines)
        {
            richText.SelectionColor = line.StartsWith(p) ? highColor : textColor;
            richText.AppendText(line + "\n");
        }
    }
