    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        string regexString = "(?<=<strong>)(.*?)(?=</strong>)";
        Match matches = (Regex.Match(richTextBox1.Text, regexString));
        if (matches.Success)
        {
            int index1 = richTextBox1.Find("<strong>");
            int index2 = richTextBox1.Find("</strong>");
            richTextBox1.Select(index1 + 3, ((index2) - (index1 + 3)));
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, FontStyle.Bold);
        }
    }
