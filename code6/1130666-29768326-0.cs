    bool LastLineVisible(TextBox textbox)
    {
        Point lowPoint = new Point(3, textbox.ClientSize.Height - 3);
        int lastline = textbox.Lines.Count() - 1;
        int charOnLastvisibleLine = textbox.GetCharIndexFromPosition(lowPoint);
        int lastVisibleLine = textbox.GetLineFromCharIndex(charOnLastvisibleLine);
        return lastVisibleLine >= lastline;
    }
