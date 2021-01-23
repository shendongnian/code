           {
                Bitmap png = new Bitmap(100, 100, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(png);
                g.Clear(Color.White);
                g.DrawString("dummy", SystemFonts.DefaultFont, Brushes.Beige, RectangleF.FromLTRB(5,5,80,80), StringFormat.GenericDefault);
                // write image to file
                string path4 = @"C:\test.png";
                png.Save(path4, System.Drawing.Imaging.ImageFormat.Png);
            }
