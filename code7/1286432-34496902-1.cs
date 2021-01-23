    Bitmap levelMeter = (Bitmap)Image.FromFile("D:\\LEDmeter0.png");
    bmpL0 = level.Clone(new Rectangle(Point.Empty, level.Size), PixelFormat.Format32bppPArgb);
    Random R = new Random(0);
    private void timer1_Tick(object sender, EventArgs e)
    {
        int level = R.Next(10) + R.Next(5) + R.Next(3) ;  // 0-17
        level = 27 * level + 50;         // magic numbers from the image
        pictureBox2.Refresh();
        using ( Graphics G = pictureBox2.CreateGraphics() )
            G.DrawImage(bmpL0, new Rectangle(0, 0, img.Width,  level),
                new Rectangle(0, 0, img.Width,  level), GraphicsUnit.Pixel);
    }
