    Bitmap bg = new Bitmap("background.png");
    Bitmap overlay = new Bitmap("colorWithAlpha.png");
    float m = 0;
    Color c;
    for (int i = 0; i < bg.Width; i++)
    {
        for (int j = 0; j < bg.Height; j++)
        {
            m = overlay.GetPixel(i, j).A / 255f;
            c = HSVtoRGB(overlay.GetPixel(i,j).GetHue(), overlay.GetPixel(i,j).GetSaturation(), bg.GetPixel(i, j).GetBrightness());
            c = Color.FromArgb((int)(m * c.R + (1 - m) * bg.GetPixel(i, j).R), (int)(m * c.G + (1 - m) * bg.GetPixel(i, j).G), (int)(m * c.B + (1 - m) * bg.GetPixel(i, j).B));
            bg.SetPixel(i, j, c);
        }
    }
