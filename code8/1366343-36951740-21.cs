    int RTBReplace(RichTextBox rtb, string oldText, string newText)
    {
        int p = 0; int count = 0;
        do
        {
            p = richTextBox1.Text.IndexOf(oldText);
            if (p >= 0)
            {
                richTextBox1.SelectionStart = p;
                richTextBox1.SelectionLength = oldText.Length;
                richTextBox1.SelectedText = newText;
                count ++;
            }
        }
        while (p >= 0);
        return count;
    }
