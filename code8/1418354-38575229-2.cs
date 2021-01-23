    private void block1_MouseEnter(object sender, MouseEventArgs e)
    {
         SetFontStyle(FontStyles.Italic);
    }
    
    private void block1_MouseLeave(object sender, MouseEventArgs e)
    {
         SetFontStyle(FontStyles.Normal);
    }
    private void SetFontStyle(FontStyle style)
    {
         block1.FontStyle = style;
    }
