    bool yellow = true;
    public void AddText(string text)
    {
        richTextBox1.SelectionStart = richTextBox1.Text.Length;
        richTextBox1.SelectionLength = 0; ;
        richTextBox1.SelectionColor = yellow ? Color.Yellow : Color.Red;
        richTextBox1.AppendText(text);
        yellow = !yellow;
    }
