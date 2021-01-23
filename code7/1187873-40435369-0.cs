        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Color pixel = new Color(b.GetPixel(i, j));
                int A = Color.GetAlphaComponent(pixel);
                int R = Color.GetRedComponent(pixel);
                int G = Color.GetGreenComponent(pixel);
                int B = Color.GetBlueComponent(pixel);
            }
        }
