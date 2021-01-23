    Bitmap bmp = new Bitmap(pictureBox1.Image);
    String text = "TextTile";
    Font font = new Font(DefaultFont.Name, 20);
    Graphics g = Graphics.FromImage(bmp);
    SizeF size = g.MeasureString(text, font);
    int w = size.ToSize().Width;
    int h = size.ToSize().Height;
    int dy = (int)((double)w * 0.7071); //sin(45)
    for (int x = 0; x < bmp.Width; x += w)
    {
        for (int y = 0; y < bmp.Height; y += dy)
        {
            g.TranslateTransform(x, y);
            g.TranslateTransform(w, h);
            g.RotateTransform(-45);
            g.TranslateTransform(-w, -h);
            g.DrawString(text, font, Brushes.Yellow, 0, 0);
            g.ResetTransform();
        }
    }
