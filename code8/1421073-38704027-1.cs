    Bitmap bmp = new Bitmap(pictureBox1.Image);
    String text = "TextTile";
    Font font = new Font(DefaultFont.Name, 20);
    Graphics g = Graphics.FromImage(bmp);
    SizeF size = g.MeasureString(text, font);
    int w = size.ToSize().Width;
    int h = size.ToSize().Height;
    int dy = (int)((double)w * Math.Sin(45.0 * Math.PI / 180.0));
    //the sin of the angle may return zero or negative value, 
    //it won't work with this formula
    if (dy < 1)
        return;
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
    pictureBox1.Image = bmp;
