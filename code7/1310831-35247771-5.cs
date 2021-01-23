    private void richTextBox2_Click(object sender, EventArgs e)
    {
        int sstart = -1;
        string s = getWordAt(richTextBox2.Text, 
                             richTextBox2.SelectionStart, delimiters, out sstart);
        if (s.Length < 3) return;
        string char1 = s.Substring(0, 1);
        if (char1 == "~")
        {
            int p = richTextBox2.Text.IndexOf("#" + s.Substring(1));
            if (p >= 0) { richTextBox2.SelectionStart = p; richTextBox2.ScrollToCaret(); }
        }
    }
    public static string getWordAt(string text, int cursorPos, 
                                   string delimiters, out int selStart)
    {
        int startPos = 0;
        selStart = startPos;
        if ((cursorPos < 0) | (cursorPos > text.Length) | (text.Length == 0)) return "";
        if ((text.Length > cursorPos) & (delimiters.Contains(text[cursorPos]))) return "";
        int endPos = text.Length - 1;
        if (cursorPos == text.Length) endPos = text.Length - 1;
        else { for (int i = cursorPos; i < text.Length; i++) 
         { if (delimiters.Contains(text[i])) { endPos = i - 1; break; } } }
        if (cursorPos == 0) startPos = 0;
        else { for (int i = cursorPos; i > 0; i--) 
        { if (delimiters.Contains(text[i])) { startPos = i + 1; break; } } }
        selStart = startPos;
        return text.Substring(startPos, endPos - startPos + 1);
    }
