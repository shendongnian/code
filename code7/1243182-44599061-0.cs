    const int MaxLineCount = 10;
    private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        TextBox textBox = (TextBox)sender;
        int textLineCount = textBox.LineCount;
        if (textLineCount > MaxLineCount)
        {
            StringBuilder text = new StringBuilder();
            for (int i = 0; i < MaxLineCount; i++)
            {
                text.Append(textBox.GetLineText((textLineCount - MaxLineCount) + i - 1));
            }
            textBox.Text = text.ToString();
        }
    }
