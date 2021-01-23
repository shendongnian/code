    List<Color> interpolateColors(List<Color> stopColors, int count)
    {
        SortedDictionary<float, Color> gradient = new SortedDictionary<float, Color>();
        for (int i = 0; i < stopColors.Count; i++)
            gradient.Add(1f * i / (stopColors.Count - 1), stopColors[i]);
        List<Color> ColorList = new List<Color>();
        using (Bitmap bmp = new Bitmap(count, 1))
        using (Graphics G = Graphics.FromImage(bmp))
        {
            Rectangle bmpCRect = new Rectangle(Point.Empty, bmp.Size);
            LinearGradientBrush br = new LinearGradientBrush
                                    (bmpCRect, Color.Empty, Color.Empty, 0, false);
            ColorBlend cb = new ColorBlend();
            cb.Positions = new float[gradient.Count];
            for (int i = 0; i < gradient.Count; i++)
                cb.Positions[i] = gradient.ElementAt(i).Key;
            cb.Colors = gradient.Values.ToArray();
            br.InterpolationColors = cb;
            G.FillRectangle(br, bmpCRect);
            for (int i = 0; i < count; i++) ColorList.Add(bmp.GetPixel(i, 0));
            br.Dispose();
        }
        return ColorList;
    }
