    static void Main(string[] args)
    {
        Image ai1 = Image.FromFile(args[0]);
        Image ai2 = Image.FromFile(args[1]);
        Bitmap i1 = new Bitmap(ai1.Width, ai1.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Bitmap i2 = new Bitmap(ai2.Width, ai2.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        using (var g1 = Graphics.FromImage(i1))
        using (var g2 = Graphics.FromImage(i2))
        {
            g1.DrawImage(ai1, Point.Empty);
            g2.DrawImage(ai2, Point.Empty);
        }
        var difference = FindDifferentPixels(i1, i2);
        var segments = Segmentize(difference);
        using (var g1 = Graphics.FromImage(i1))
        {
            foreach (var segment in segments)
            {
                g1.DrawRectangle(Pens.Red, new Rectangle(segment.Left, segment.Top, segment.Right - segment.Left, segment.Bottom - segment.Top));
            }
        }
        i1.Save("result.png");
        Console.WriteLine("Done.");
        Console.ReadKey();
    }
