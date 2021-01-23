    private void txtFontName_TextChanged(object sender, EventArgs e)
    {
        ChangeFontTypeAndSize();
                
    }
    
    private void txtFontSize_TextChanged(object sender, EventArgs e)
    {
        ChangeFontTypeAndSize();
    }
    private void ChangeFontTypeAndSize()
    {
        string fontName = txtFontName.Text;
        Font font = new Font(fontName, float.Parse((txtFontSize.Text == "" ? "11" : txtFontSize.Text)));
        label1.Font = font;
    }
