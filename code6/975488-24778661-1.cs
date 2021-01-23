    private void Form1_Load(object sender, EventArgs e)
    {
        prepareFont(fontImageFileName);
    }
    Dictionary<char, Bitmap> theFont = new Dictionary<char, Bitmap>();
    string fontImageFileName = @"D:\yourfontimage.png";
    string fontCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    int fontCharsPerLine = 7;
    int fontCharsLines = 5;
    int fontCharPixelWidth = 63;
    int fontCharPixelHeight = 87;
    void prepareFont(string fontImageFile)
    {
        Rectangle destRect = new Rectangle(0, 0, fontCharPixelWidth, fontCharPixelHeight );
        using (Bitmap bmp = new Bitmap(fontImageFileName))
            for (int y = 0; y < fontCharsLines; y++)
            for (int x = 0; x < fontCharsPerLine; x++)
            {
                if (x + y * fontCharsPerLine < fontCharacters.Length)
                {
                   char c = fontCharacters[x + y * fontCharsPerLine];
                   Bitmap glyph = new Bitmap(fontCharPixelWidth, fontCharPixelHeight);
                   using (Graphics G = Graphics.FromImage(glyph))
                   {
                       G.DrawImage(bmp, destRect, fontCharPixelWidth * x, fontCharPixelHeight * y,
                            fontCharPixelWidth, fontCharPixelHeight, GraphicsUnit.Pixel);
                       theFont.Add(c, glyph);
                   }
                }
            }
    }
    void disposeFont()
    {
        foreach (char c in theFont.Keys) theFont[c].Dispose();
        theFont.Clear();
    }
    void drawFontString(Graphics G, string text, Point location)
    {
        int offset = 0;
        foreach (char c in text)
        {
            if (theFont.Keys.Contains(c))
            {
                G.DrawImage(theFont[c], new Point(location.X + offset, location.Y));
                offset += fontCharPixelWidth;
            }
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        using (Graphics G = panel1.CreateGraphics())
        { drawFontString(G, textBox1.Text, Point.Empty); }
    }
