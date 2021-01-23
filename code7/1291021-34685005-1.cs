    ColorPalette pal = newBitmap.Palette;
                    for (int i = 0; i <= 255; i++)
                    {
                        // create greyscale color table
                        pal.Entries[i] = Color.FromArgb(i, i, i);
                    }
                    newBitmap.Palette = pal; // you need to re-set this property to force the new ColorPalette
