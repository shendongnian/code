    private void label1_Paint(object sender, PaintEventArgs e)
    {
        Rectangle rec = e.ClipRectangle;
        using (LinearGradientBrush brush = 
           new LinearGradientBrush(rec, Color.Transparent, Color.Blue, 0f))
        {
            ColorBlend cblend = new ColorBlend(4);
            cblend.Colors = new Color[4] { Color.Transparent, Color.DarkSlateGray,
                                           Color.DarkSlateGray, Color.Transparent };
            cblend.Positions = new float[4] { 0f, 0.15f, 0.85f, 1f };
            brush.InterpolationColors = cblend;
            e.Graphics.FillRectangle(brush, rec);
        }
        Font font = new Font("Tahoma", 10f, FontStyle.Bold);
        TextFormatFlags fmt = new TextFormatFlags();
        fmt = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
        TextRenderer.DrawText(e.Graphics, "Hello", font, rec, 
                              Color.White, Color.Transparent, fmt);
  
    }
