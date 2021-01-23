    public static void DrawImage(Bitmap source)
    {
        int width = Console.WindowWidth - 1;
        int height = (int)(width * source.Height / 2.0 / source.Width);
        using (var bmp = new Bitmap(source, width, height))
        {
            var unit = GraphicsUnit.Pixel;
            using (var src = bmp.Clone(bmp.GetBounds(ref unit), PixelFormat.Format24bppRgb))
            {
                var bits = src.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, src.PixelFormat);
                byte[] data = new byte[bits.Stride * bits.Height];
                Marshal.Copy(bits.Scan0, data, 0, data.Length);
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        int idx = j * bits.Stride + i * 3;
                        DrawPixel(data[idx + 2], data[idx + 1], data[idx + 0]);
                    }
                    Console.WriteLine();
                }
                Console.ResetColor();
            }
        }
    }
    private static void DrawPixel(int r, int g, int b)
    {
        var l = RGBtoLab(r, g, b);
        double diff = double.MaxValue;
        var pixel = pixels[0];
        foreach (var item in pixels)
        {
            var delta = CieLab.DeltaE(l, item.Lab);
            if (delta < diff)
            {
                diff = delta;
                pixel = item;
            }
        }
        Console.ForegroundColor = pixel.Forecolor;
        Console.BackgroundColor = pixel.Backcolor;
        Console.Write(pixel.Char);
    }
