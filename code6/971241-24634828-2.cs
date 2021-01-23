    public void SetText(string text)
    {
        if (Format == "") Format = "{0}";
        Text = string.Format(Format, text);
    }
