    List<Color> interpolateColors(List<Color> stopColors, int count)
    {
        List<Color> ColorList = new List<Color>();
        using (Bitmap bmp = new Bitmap(count, 1))
        using (Graphics G = Graphics.FromImage(bmp))
        {
            Rectangle bmpCRect = new Rectangle(Point.Empty, bmp.Size);
            LinearGradientBrush br = new LinearGradientBrush
                                    (bmpCRect, Color.Empty, Color.Empty, 0, false);
            ColorBlend cb = new ColorBlend();
            cb.Colors = stopColors.ToArray();
            float[]  Positions = new float[stopColors.Count];
            for (int i = 0; i < stopColors.Count; i++) 
                  Positions [i] = 1f * i / (stopColors.Count-1);
            cb.Positions = Positions;
            br.InterpolationColors = cb;
            G.FillRectangle(br, bmpCRect);
            for (int i = 0; i < count; i++) ColorList.Add(bmp.GetPixel(i, 0));
            br.Dispose();
        }
        return ColorList;
    }
