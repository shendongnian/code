    int ColorWord(RichTextBox rtb, string word, Color foreColor, Color backColor)
    {
        string wordPattern  = @"\b" + word +  @"\b";
        var matches = Regex.Matches(rtb.Text, wordPattern);
        for (int i = matches.Count - 1; i >= 0; i--)
        {
            var m = matches[i];
            rtb.SelectionStart = m.Index;
            rtb.SelectionLength = m.Length;
            rtb.SelectionColor = foreColor;
            rtb.SelectionBackColor = backColor;
        }
        return matches.Count;
    }
