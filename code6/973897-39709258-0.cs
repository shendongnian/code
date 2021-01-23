    public static void GetBitmap(string file)
            {
                using (Bitmap img = new Bitmap(file, true))
                {    
                    // Variable for image brightness
                    double avgBright = 0;
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (int x = 0; x < img.Width; x++)
                        {
                            // Get the brightness of this pixel
                            avgBright += img.GetPixel(x, y).GetBrightness();
                        }
                    }
    
                    // Get the average brightness and limit it's min / max
                    avgBright = avgBright / (img.Width * img.Height);
                    avgBright = avgBright < .3 ? .3 : avgBright;
                    avgBright = avgBright > .7 ? .7 : avgBright;
    
                    // Convert image to black and white based on average brightness
                    for (int y = 0; y < img.Height; y++)
                    {
                        for (int x = 0; x < img.Width; x++)
                        {
                            // Set this pixel to black or white based on threshold
                            if (img.GetPixel(x, y).GetBrightness() > avgBright) img.SetPixel(x, y, Color.White);
                            else img.SetPixel(x, y, Color.Black);
                        }
                    }
                    
                    // Image is now in black and white
                }
