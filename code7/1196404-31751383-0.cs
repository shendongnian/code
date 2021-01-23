        public static void DetectSkin(Bitmap original, ref Bitmap modified)
        {
            Graphics g = Graphics.FromImage(original);
            ArrayList points = new ArrayList();
            for (Int32 x = 0; x < original.Width; x++)
            {
                for (Int32 y = 0; y < original.Height; y++)
                {
                    Color c = modified.GetPixel(x, y);
                    double I = (Math.Log(c.R) + Math.Log(c.B) + Math.Log(c.G)) / 3;
                    double Rg = Math.Log(c.R) - Math.Log(c.G);
                    double By = Math.Log(c.B) - (Math.Log(c.G) + Math.Log(c.R)) / 2;
                    double hue = Math.Atan2(Rg, By) * (180 / Math.PI);
                    if (I <= 5 && (hue >= 4 && hue <= 255))
                    {
                        points.Add(new Point(x, y));
                    }
                    else
                    {
                        modified.SetPixel(x, y, Color.Black);
                    }
                }
            }
        }
