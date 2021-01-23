    private static Image ToGrayscale(Image s,int alpha)
            {
                Bitmap tImage = new Bitmap(s);
    
                for (int x = 0; x < tImage.Width; x++)
                {
                    for (int y = 0; y < tImage.Height; y++)
                    {
                        Color tCol = tImage.GetPixel(x, y);
                        Color newColor = Color.FromArgb(alpha, tCol.R, tCol.G, tCol.B);
                      tImage.SetPixel(x, y, newColor);
                    }
                }
                return tImage;
    
            }
