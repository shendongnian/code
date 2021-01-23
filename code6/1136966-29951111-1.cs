    private void Form1_Load(object sender, EventArgs e)
    {
        using (Graphics G = panel2.CreateGraphics() )
        {
            fonts.Add(new DrawFont(G, new FontFamily("Arial"), 7f));
            fonts.Add(new DrawFont(G, new FontFamily("Arial"), 12f));
            fonts.Add(new DrawFont(G, new FontFamily("Arial"), 17f));
            fonts.Add(new DrawFont(G, new FontFamily("Consolas"), 8f));
            fonts.Add(new DrawFont(G, new FontFamily("Consolas"), 10f));
            fonts.Add(new DrawFont(G, new FontFamily("Consolas"), 14f));
            fonts.Add(new DrawFont(G, new FontFamily("Times"), 9f));
            fonts.Add(new DrawFont(G, new FontFamily("Times"), 12f));
            fonts.Add(new DrawFont(G, new FontFamily("Times"), 20f));
            fonts.Add(new DrawFont(G, new FontFamily("Segoe Print"), 6f));
            fonts.Add(new DrawFont(G, new FontFamily("Segoe Print"), 12f));
            fonts.Add(new DrawFont(G, new FontFamily("Segoe Print"), 24f));
        }
    }
    List<DrawFont> fonts = new List<DrawFont>();
    class DrawFont
    {
        public Font Font { get; set; }
        public float baseLine { get; set; }
        public DrawFont(Graphics G, FontFamily FF, float height, FontStyle style)
        {
            Font = new Font(FF, height, style);
            float lineSpace = FF.GetLineSpacing(Font.Style);
            float ascent = FF.GetCellAscent(Font.Style);
            baseLine = Font.GetHeight(G) * ascent / lineSpace;
        }
    }
    private void panel2_Paint(object sender, PaintEventArgs e)
    {
        float x = 5f;
        foreach ( DrawFont font in fonts )
        {
            e.Graphics.DrawString("Fy", font.Font, Brushes.DarkSlateBlue, x, 80 - font.baseLine);
            x += 50;
        }
        e.Graphics.DrawLine(Pens.LightSlateGray, 0, 80, 999, 80);
    }
