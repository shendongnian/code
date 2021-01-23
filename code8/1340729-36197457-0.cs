    public Bitmap Update()
    {
        Bitmap background = new Bitmap(301, 67);
        Graphics g = Graphics.FromImage(background);
        g.Clear(color: Color.White);
        Bitmap buffer = CreateBackgroundBitmap();
        g.DrawImage(buffer, new Rectangle(0, 0, 301, 67), 0.0f, 0.0f, 301, 67, GraphicsUnit.Pixel, this.GetImageAttributes());
        if (State == Powerstate.on)
        {
            for (int i = 0; i < digits.Count(); i++)
            {
                DrawSegment(ref g, digits[i], i);
                if (digits[i]?.Dot == Dot.dot_on)
                {
                    DrawPoint(ref g, digits[i], i);
                }
            }
        }
        return background;
    }
