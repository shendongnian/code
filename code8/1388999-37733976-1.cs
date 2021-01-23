    private void DrawLetter()
    {
        var letter = counter.ToString();
        Graphics g = timerForm.CreateGraphics();
        float width = ClientRectangle.Width;
        float height = ClientRectangle.Width;
        float emSize = height;
        using (Font font1 = new Font(FontFamily.GenericSansSerif, emSize, FontStyle.Regular))
        using (Font font2 = FindBestFitFont(g, letter, font1, ClientRectangle.Size))
        using (var brush = new SolidBrush(Color.White))
        {
            SizeF size = g.MeasureString(letter, font2);
            g.Clear(SystemColors.Control);
            g.DrawString(letter, font2, brush, (width - size.Width) / 2, 0);
        }
    }
