    private StringBuilder stringBuilder = new StringBuilder();
    private bool _isInsideTextChanged = false;
    private const int MaximumChars = 30; // Maximum characters
     
    private StringBuilder WrapText(StringBuilder text, ref int position)
    {
        StringBuilder newStringBuilder = new StringBuilder(text.ToString());
        int charsPerLine = 0;
        int lastSpace = -1; // index of last space per line
        for (int i = 0; i < newStringBuilder.Length; i++)
        {
            if (newStringBuilder[i] == ' ')
            {
                if (newStringBuilder.Length > i + 2 && newStringBuilder.ToString(i + 1, 2) == "\r\n")
                {
                    if (newStringBuilder.Length > i + 3)
                    {
                        int next = newStringBuilder.ToString().IndexOf(' ', i + 3);
                        if (next != -1 && charsPerLine + next - i <= 30 || charsPerLine + newStringBuilder.Length - i - 2 <= 30)
                        {
                            newStringBuilder.Remove(i + 1, 2);
                            if (i <= textBox1.SelectionStart)
                            {
                                position -= 2;
                            }
                            continue;
                        }
                    }
                    i++;
                    continue;
                }
                if (newStringBuilder.Length > i + 1 && newStringBuilder[i + 1] != ' ')
                {
                    lastSpace = i;
                }
            }
            if (newStringBuilder[i] == '\n' || newStringBuilder[i] == '\r')
            {
                lastSpace = -1;
                charsPerLine = 0;
            }
            if (++charsPerLine > MaximumChars && lastSpace != -1)
            {
                newStringBuilder.Insert(lastSpace + 1, "\r\n");
                if (lastSpace <= textBox1.SelectionStart)
                {
                    position += 2;
                }
                
                charsPerLine = i - lastSpace;
                lastSpace = -1;
                i++;
            }
        }
        return newStringBuilder;
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        if (_isInsideTextChanged) return;
        _isInsideTextChanged = true;
        
        stringBuilder.Clear();
        stringBuilder.Append(textBox1.Text);
        int position = textBox1.SelectionStart;
        string newText = WrapText(stringBuilder, ref position).ToString();
        textBox1.Text = newText;
        textBox1.SelectionStart = position;
        _isInsideTextChanged = false;
    }
