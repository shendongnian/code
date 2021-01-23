            for (int y = 0; y < width; y++)
            {
                for (int x = 0; x < height; x++)
                {
                    int red = imageData[offset + 3 * x] ;
                    int green = imageData[offset + 3 * x + 1];
                    int blue = imageData[offset + 3 * x + 2];
                    Color color = Color.FromArgb(red, green, blue);
                    bitmap.SetPixel(y, x, color);
                }
                offset += 3 * height;
            }
