        while (run<4)
            {
                Bitmap bmDestination = new Bitmap(l, l);
                for (i = 0; i < bmDestination.Height; ++i)
                {
                    radius = (double)(l - i);
                    for (j = run * l, k = 0; j < lastWidth * l||k < bmDestination.Width; ++j, ++k)
                    {
                        // theta = 2.0 * Math.PI * (double)(4.0 * l - j) / (double)(4.0 * l);
                        theta = 2.0 * Math.PI * (double)(-j) / (double)(4.0 * l);
                        fTrueX = radius * Math.Cos(theta);
                        fTrueY = radius * Math.Sin(theta);
                        // "normal" mode
                        x = (int)(Math.Round(fTrueX)) + l;
                        y = l - (int)(Math.Round(fTrueY));
                        // check bounds
                        if (x >= 0 && x < iSourceWidth && y >= 0 && y < iSourceWidth)
                        {
                            bmDestination.SetPixel(k, i, bm.GetPixel(x, y));
                        }
                    }
