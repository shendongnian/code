    private Bold _text;
    public CustomMessageBox(Bold formattedText)
    {
       _text = formattedText;
       GridContent.Child = _text;
    }
