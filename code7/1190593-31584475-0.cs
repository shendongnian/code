    public delegate void FontSize(int size);
    public event FontSize OnFontSizeChanged;
    public void WhereYouChangeFontSize()
    {
      // Change font size
      OnFontSizeChanged(newFontSize)
    }
