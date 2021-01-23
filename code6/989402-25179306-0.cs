    List<Color> colors = new List<Color>();
    for (int r = 0; r < 256; r++)
    {
        for (int g = 0; g < 256; g++)
        {
            for (int b = 0; b < 256; b++)
            {
                colors.Add(Color.FromArgb(r,g,b));
            }
        }
    }
