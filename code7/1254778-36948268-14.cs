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
                    StringBuilder builder = new StringBuilder();
                    var fore = ConsoleColor.White;
                    var back = ConsoleColor.Black;
                    for (int i = 0; i < width; i++)
                    {
                        int idx = j * bits.Stride + i * 3;
                        var pixel = DrawPixel(data[idx + 2], data[idx + 1], data[idx + 0]);
                        if (pixel.Forecolor != fore || pixel.Backcolor != back)
                        {
                            Console.ForegroundColor = fore;
                            Console.BackgroundColor = back;
                            Console.Write(builder);
                            builder.Clear();
                        }
                        fore = pixel.Forecolor;
                        back = pixel.Backcolor;
                        builder.Append(pixel.Char);
                    }
                    Console.ForegroundColor = fore;
                    Console.BackgroundColor = back;
                    Console.WriteLine(builder);
                }
                Console.ResetColor();
            }
        }
    }
    private static ConsolePixel DrawPixel(int r, int g, int b)
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
        return pixel;
    }
